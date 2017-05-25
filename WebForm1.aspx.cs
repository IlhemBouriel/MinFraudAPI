using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MinFraudAPI
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblScore;
		protected System.Web.UI.WebControls.Label lblResults;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtIP;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtCountry;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtBin;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblSafe;
		protected System.Web.UI.WebControls.Button btnCheck;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCheck_Click(object sender, System.EventArgs e)
		{
			CCInfo ccInfo = new CCInfo();
			ccInfo.IP = txtIP.Text;
			ccInfo.City = txtCity.Text;
			ccInfo.State = txtState.Text;
			ccInfo.ZipCode = txtZip.Text;
			ccInfo.Country = txtCountry.Text;
			ccInfo.EMail = txtEmail.Text;
			ccInfo.Phone = txtPhone.Text;
			ccInfo.Bin = txtBin.Text;

			double fraudScore;
			string info;
			if (MinFraud.IsSafe(ccInfo,out fraudScore,out info))
			{
				lblSafe.ForeColor = Color.Green;
				lblSafe.Text = "Yes";
			}
			else
			{
				lblSafe.ForeColor = Color.Red;
				lblSafe.Text = "No";
			}

			lblScore.Text = fraudScore.ToString();
			lblResults.Text = info;
		}
	}
}
