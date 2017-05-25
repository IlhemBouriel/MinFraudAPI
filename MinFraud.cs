using System;
using System.Web;
using System.Net;
using System.IO;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace MinFraudAPI
{
	/// <summary>
	/// MinFraud API for detection of credit card fraud
	/// </summary>
	public class MinFraud
	{
		private const string _minFraudAddress = "https://www.maxmind.com/app/ccv2r";
		private const string _minFraudAddress2 = "https://www2.maxmind.com/app/ccv2r";

		private const string _minFraudKey = "yourkeyhere";
		private const double _fraudLimit = 2.7; // Set to your risk tolerance threshold

		public MinFraud()
		{
		}

		/// <summary>
		/// Check if sale is safe to accept
		/// </summary>
		/// <param name="ccInfo"></param>
		/// <param name="fraudScore"></param>
		/// <param name="info"></param>
		/// <returns></returns>
		public static bool IsSafe(CCInfo ccInfo, out double fraudScore,out string info)
		{
			bool safe = false;
			fraudScore = 10.0;
			info = string.Empty;

			HttpWebResponse webResponse = null;

			try
			{				
				// Write the request to gateway (required data)
				string reqString = "i=" + ccInfo.IP;
				reqString += "&city=" + HttpUtility.UrlEncode(ccInfo.City);
				reqString += "&region=" + HttpUtility.UrlEncode(ccInfo.State);
				reqString += "&postal=" + HttpUtility.UrlEncode(ccInfo.ZipCode);
				reqString += "&country=" + HttpUtility.UrlEncode(ccInfo.Country);
				reqString += "&license_key=" + _minFraudKey;

				// optional data
				if (ccInfo.Phone.Length > 0)
				{
					reqString += "&custPhone=" + ccInfo.Phone;
				}
				if (ccInfo.Bin.Length > 0)
				{
					reqString += "&bin=" + ccInfo.Bin;
				}

				// Calc MD5 on email
				if (ccInfo.EMail.Length > 0)
				{
					string emailDomain = ccInfo.EMail.Substring(ccInfo.EMail.IndexOf("@")+1);
					reqString += "&domain=" + emailDomain;
					reqString += "&emailMD5=" + EmailHash(ccInfo.EMail);
				}

				// Find content length
				UTF8Encoding encoding = new UTF8Encoding();
				Byte[] byteArray = encoding.GetBytes(reqString);

				// Create the request back
				HttpWebRequest req = (HttpWebRequest) WebRequest.Create(_minFraudAddress);

				try
				{
					// Set values for the request back
					req.ContentLength = byteArray.Length;
					req.Method = "POST";
					req.ContentType = "application/x-www-form-urlencoded";
					req.Timeout = 5000;

					using (Stream requestStream = req.GetRequestStream()) 
					{
						requestStream.Write(byteArray,0,byteArray.Length);
						requestStream.Close();
					}					

					// Do the request to Gateway and get the response
					webResponse = (HttpWebResponse)req.GetResponse();
				}
				catch
				{
					if (null != webResponse)
					{
						webResponse.Close();
					}

					// Attempt to use secondary server
					req = (HttpWebRequest) WebRequest.Create(_minFraudAddress2);

					// Set values for the request back
					req.ContentLength = byteArray.Length;
					req.Method = "POST";
					req.ContentType = "application/x-www-form-urlencoded";
					req.Timeout = 5000;

					using (Stream requestStream = req.GetRequestStream()) 
					{
						requestStream.Write(byteArray,0,byteArray.Length);
						requestStream.Close();
					}			
					webResponse = (HttpWebResponse)req.GetResponse();		
				}

				Stream strm = webResponse.GetResponseStream();
				StreamReader stIn = new StreamReader(strm);
				info = stIn.ReadToEnd();
				stIn.Close();					

				// Check response for errors and such
				char[] splitChars = {';'};
				string[] respCodes = info.Split(splitChars);

				foreach(string s in respCodes)
				{
					if (-1 != s.IndexOf("score="))
					{
						fraudScore = double.Parse(HttpUtility.UrlDecode(s.Substring(s.IndexOf("=")+1)));

						safe = (fraudScore < _fraudLimit);
						break; // nothing else to do for now
					}
				}
			}
			catch 
			{
				// Log exception
			}
			finally
			{
				if (null != webResponse)
				{
					webResponse.Close();
				}
			}

			return safe;
		}

		/// <summary>
		/// Hash the email string
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		private static string EmailHash(string email)
		{
			// Must be lower case before hashing
			email = email.ToLower();

			Encoder enc = System.Text.Encoding.UTF8.GetEncoder();

			// Create a buffer large enough to hold the string
			byte[] byteText = new byte[email.Length];
			enc.GetBytes(email.ToCharArray(), 0, email.Length, byteText, 0, true);

			// Now that we have a byte array we can ask the CSP to hash it
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] result = md5.ComputeHash(byteText);

			// Build the final string by converting each byte
			// into hex and appending it to a StringBuilder
			StringBuilder downloadHash = new StringBuilder();
			foreach(byte b in result)
			{
				downloadHash.Append(Convert.ToString(b,16).PadLeft(2,'0'));
			}

			return downloadHash.ToString();
		}
	}
}
