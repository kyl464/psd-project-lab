using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            
        }

        protected void gv_TransactionHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}