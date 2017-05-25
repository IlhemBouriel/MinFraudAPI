# MinFraudAPI

Machine learning project for fraud detection <br />
ML algorithm used is Logistic Regression <br />
## Code Example
Calling MinFraudApi as a POST Web Service<br />
  // Attempt to use secondary server<br />
					req = (HttpWebRequest) WebRequest.Create(_minFraudAddress2);<br />

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
<br />
<br />
From the received data ,we can confirm if there is a fraud or not. </br>
//it's a Set to your risk tolerance threshold</br>
_fraudLimit = 2.7; // 
foreach(string s in respCodes)
				{
					if (-1 != s.IndexOf("score="))
					{
						fraudScore = double.Parse(HttpUtility.UrlDecode(s.Substring(s.IndexOf("=")+1)));<br />

						safe = (fraudScore < _fraudLimit);
						break; // nothing else to do for now
					}
				}
## Installation
ASP.Net App
download the vs solution and run it from vs editor
