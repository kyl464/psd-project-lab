using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDProject.Controller;
using PSDProject.Model;

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
            HttpCookie cookie = Request.Cookies["session"];
            return int.Parse(cookie["userID"]);
        }

        protected void gv_TransactionHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ambil TransactionID dari row yang dipilih
            int transactionID = Convert.ToInt32(gv_TransactionHistory.SelectedDataKey.Value);

            // Redirect ke halaman TransactionDetails.aspx dengan query string TransactionID
            Response.Redirect($"TransactionDetails.aspx?TransactionID={transactionID}");
        }

        protected void gv_TransactionHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Pastikan rowIndex berada dalam rentang yang valid
                if (rowIndex >= 0 && rowIndex < gv_TransactionHistory.Rows.Count)
                {
                    int transactionID = Convert.ToInt32(gv_TransactionHistory.DataKeys[rowIndex]["TransactionID"]);

                    // Redirect ke halaman TransactionDetails.aspx dengan query string TransactionID
                    Response.Redirect($"TransactionDetails.aspx?TransactionID={transactionID}");
                }
                else
                {
                    // Tangani kasus di mana rowIndex di luar rentang yang valid
                    // Misalnya, tampilkan pesan kesalahan atau log ke konsol
                    // atau lakukan tindakan pemulihan lainnya.
                    Response.Write("Error: Row index is out of range.");
                }
            }
        }


    }
}
