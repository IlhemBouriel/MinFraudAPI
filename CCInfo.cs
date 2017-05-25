using System;

namespace MinFraudAPI
{
	/// <summary>
	/// Holder for credit card information to be passed to fraud detection
	/// </summary>
	public class CCInfo
	{
		// required fields
		private string		_ip;
		private string		_city;
		private string		_state;
		private string		_zip;			// zip code
		private string		_country;

		// optional
		private string		_ccBin;		// First 6 digits of credit card
		private string		_email;
		private string		_phone;


		public CCInfo()
		{
		}


		/// <summary>
		/// First 6 digits of credit card
		/// </summary>
		public string Bin
		{
			get {return _ccBin;}
			set {_ccBin = value;}
		}

		/// <summary>
		/// City
		/// </summary>
		public string City
		{
			get {return _city;}
			set {_city = value;}
		}

		/// <summary>
		/// State/Region
		/// </summary>
		public string State
		{
			get {return _state;}
			set {_state = value;}
		}

		/// <summary>
		/// Country Code (e.g. US, CA)
		/// </summary>
		public string Country
		{
			get {return _country;}
			set {_country = value;}
		}

		/// <summary>
		/// Zip/Postal code
		/// </summary>
		public string ZipCode
		{
			get {return _zip;}
			set {_zip = value;}
		}

		/// <summary>
		/// Email address
		/// </summary>
		public string EMail
		{
			get {return _email;}
			set {_email = value;}
		}

		/// <summary>
		/// Customer phone number
		/// </summary>
		public string Phone
		{
			get {return _phone;}
			set {_phone = value;}
		}

		/// <summary>
		/// Customer IP
		/// </summary>
		public string IP
		{
			get {return _ip;}
			set {_ip = value;}
		}
	}
}
