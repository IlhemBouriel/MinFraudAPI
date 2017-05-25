# MinFraudAPI

Machine learning project for fraud detection <br />
ML algorithm used is Logistic Regression <br />
## Code Example
Calling MinFraudApi as a POST Web Service<br />
  // Attempt to use secondary server<br />
					req = (HttpWebRequest) WebRequest.Create(_minFraudAddress2);<br />

					// Set values for the request back<br />
					req.ContentLength = byteArray.Length;<br />
					req.Method = "POST";<br />
					req.ContentType = "application/x-www-form-urlencoded";<br />
					req.Timeout = 5000;<br />

					using (Stream requestStream = req.GetRequestStream()) <br />
					{<br />
						requestStream.Write(byteArray,0,byteArray.Length);<br />
						requestStream.Close();<br />
					}			<br />
					webResponse = (HttpWebResponse)req.GetResponse();	<br />
<br />
<br />
From the received data ,we can confirm if there is a fraud or not. </br>
In our case _fraudLimit = 2.7; // it's a Set to your risk tolerance threshold
foreach(string s in respCodes)<br />
				{<br />
					if (-1 != s.IndexOf("score="))<br />
					{<br />
						fraudScore = double.Parse(HttpUtility.UrlDecode(s.Substring(s.IndexOf("=")+1)));<br />

						safe = (fraudScore < _fraudLimit);<br />
						break; // nothing else to do for now<br />
					}<br />
				}<br />
## Installation
ASP.Net App
download the vs solution and run it from vs editor
