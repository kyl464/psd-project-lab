using PSDProject.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class Home : System.Web.UI.Page
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
            HttpCookie cookie = Request.Cookies["session"];
            if (cookie == null || cookie["role"] != "Admin")
            {
                btn_insert.Visible = false;
            }
            
            gv_stationeries.DataSource = StationeryController.GetAllStationeries();
            gv_stationeries.DataBind();
        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertStationery.aspx");
        }
    }
}