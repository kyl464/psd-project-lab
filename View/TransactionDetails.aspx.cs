using PSDProject.Controller;
using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class TransactionDetails : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            HttpCookie cookie = Request.Cookies["session"];
            if (cookie != null)
            {
                Page.MasterPageFile = "~/Master/LoggedInMaster.Master";
            }
            else
            {
                Page.MasterPageFile = "~/Master/GuestMaster.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["TransactionID"] != null)
                {
                    int transactionID = Convert.ToInt32(Request.QueryString["TransactionID"]);
                    BindTransactionDetails(transactionID);
                }
            }
        }

        private void BindTransactionDetails(int transactionID)
        {
            List<TransactionDetail> transactionDetails = TransactionController.GetTransactionDetails(transactionID);
            gvTransactionDetails.DataSource = transactionDetails;
            gvTransactionDetails.DataBind();
        }
    }
}
