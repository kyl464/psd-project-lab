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
            if (cookie != null)
            {
                int userID;
                if (int.TryParse(cookie.Values["userID"], out userID))
                {
                    Session["UserID"] = userID;
                }
            }

            if (!IsPostBack)
            {
                if (cookie == null || cookie["role"] != "Admin")
                {
                    btn_insert.Visible = false;
                }

                gv_stationeries.DataSource = StationeryController.GetAllStationeries();
                gv_stationeries.DataBind();
            }
        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertStationery.aspx");
        }

        protected void gv_stationeries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hlStationeryDetails = (HyperLink)e.Row.FindControl("hlStationeryDetails");
                Label lblStationeryName = (Label)e.Row.FindControl("lblStationeryName");

                HttpCookie cookie = Request.Cookies["session"];
                if (cookie == null || (cookie["role"] != "Admin" && cookie["role"] != "Customer"))
                {
                    hlStationeryDetails.Visible = false;
                    lblStationeryName.Visible = true;
                }
                else
                {
                    hlStationeryDetails.Visible = true;
                    lblStationeryName.Visible = false;
                }
            }
        }
    }
}
