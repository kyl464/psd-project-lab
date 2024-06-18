using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDProject.Controller;
using PSDProject.Model;
using PSDProject.Module;

namespace PSDProject.View
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            HttpCookie cookie = Request.Cookies["session"];
            if (cookie != null)
            {
                SessionCookie.createSession(Session, cookie);
            }
            
            if (Session["userID"] != null)
            {
                Page.MasterPageFile = "~/Master/LoggedInMaster.Master";
            }
            else
            {
                Response.Redirect("~/View/Login.aspx");
                Page.MasterPageFile = "~/Master/GuestMaster.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransactionHistory();
            }
        }

        private void BindTransactionHistory()
        {
            int userID = GetLoggedInUserID();
            var transactions = TransactionController.GetTransactionsByUserID(userID);
            gv_TransactionHistory.DataSource = transactions;
            gv_TransactionHistory.DataBind();
        }

        private int GetLoggedInUserID()
        {
            return int.Parse(Session["userID"].ToString());
        }

        protected void gv_TransactionHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int transactionID = Convert.ToInt32(gv_TransactionHistory.SelectedDataKey.Value);

           
            Response.Redirect($"TransactionDetails.aspx?TransactionID={transactionID}");
        }

        protected void gv_TransactionHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                
                if (rowIndex >= 0 && rowIndex < gv_TransactionHistory.Rows.Count)
                {
                    int transactionID = Convert.ToInt32(gv_TransactionHistory.DataKeys[rowIndex]["TransactionID"]);

                   
                    Response.Redirect($"TransactionDetails.aspx?TransactionID={transactionID}");
                }
                else
                {
                    
                    Response.Write("Error: Row index is out of range.");
                }
            }
        }


    }
}
