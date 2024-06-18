using PSDProject.Controller;
using PSDProject.Model;
using PSDProject.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class UpdateStationery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["session"];
                if (cookie != null)
                {
                    SessionCookie.createSession(Session, cookie);
                }
                if (Session["userID"] == null || Session["userRole"].ToString() != "Admin")
                {
                    Response.Redirect("~/View/Login.aspx");
                }

                int id = GetStationeryID();
                MsStationery stationery = StationeryController.GetStationery(id);
                txt_stationeryname.Text = stationery.StationeryName;
                txt_stationeryprice.Text = stationery.StationeryPrice.ToString();
            }
            
        }

        protected int GetStationeryID()
        {
            return int.Parse(Request["id"]);
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            int id = GetStationeryID();
            string name = txt_stationeryname.Text;
            int price = int.Parse(txt_stationeryprice.Text);
            Result<MsStationery> result = StationeryController.UpdateStationery(id, name, price);

            if (result.status)
            {
                Response.Redirect("~/View/Home.aspx");
            }
            else
            {
                lbl_error.Text = result.message;
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }
    }
    
}