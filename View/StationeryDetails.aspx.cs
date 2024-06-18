using PSDProject.Controller;
using PSDProject.Handler;
using PSDProject.Model;
using PSDProject.Module;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class StationeryDetails : System.Web.UI.Page
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
                Page.MasterPageFile = "~/Master/GuestMaster.Master";
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                int userID = Convert.ToInt32(Session["userID"]);
                

                if (Request.QueryString["ID"] != null)
                {
                    int stationeryID = Convert.ToInt32(Request.QueryString["ID"]);
                    

                    MsStationery stationery = StationeryController.GetStationery(stationeryID);
                    BindStationeryData(stationery);
                }
            }
        }

        private void BindStationeryData(MsStationery stationery)
        {
            gvStationeryDetails.DataSource = new List<MsStationery> { stationery };
            gvStationeryDetails.DataBind();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            
            try
            {
                int userID = Convert.ToInt32(Session["UserID"]);
                int stationeryID = Convert.ToInt32(Request.QueryString["ID"]);
                int quantity = int.Parse(txtQuantity.Text);

              
                System.Diagnostics.Debug.WriteLine($"UserID: {userID}, StationeryID: {stationeryID}, Quantity: {quantity}");

                PSDProject.Model.Cart cart = CartHandler.CreateOrUpdateCart(userID, stationeryID, quantity);
               
                Response.Write("<script>alert('Item added to cart successfully.');</script>");
            }
            catch (Exception ex)
            {
                
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }


    }
}
