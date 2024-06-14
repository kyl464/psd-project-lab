using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                if (cookie == null)
                {
                    Response.Redirect("~/View/Login.aspx");
                    return;
                }
                if (cookie["role"] == "Customer")
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
            Session.Clear();
            Response.Redirect("~/View/Login.aspx");
        }
        
    }
}