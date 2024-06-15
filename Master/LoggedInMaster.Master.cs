using PSDProject.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.Master
{
    public partial class LoggedInMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["session"];
                if(cookie != null)
                {
                    SessionCookie.createSession(Session, cookie);
                }
                if (Session["userID"] == null)
                {
                    Response.Redirect("~/View/Login.aspx");
                    return;
                }
                if (Session["userRole"].ToString() == "Customer")
                {
                    btn_report.Visible = false;
                }
                else
                {
                    btn_transaction.Visible = false;
                    btn_cart.Visible = false;
                }
            }
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["session"];
            if(cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }                  
            Session.Clear();
            Response.Redirect("~/View/Login.aspx");
        }

        protected void btn_report_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn_transaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionHistory.aspx");
        }

        protected void btn_cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Cart.aspx");
        }
    }
}