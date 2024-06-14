using PSDProject.Controller;
using PSDProject.Handler;
using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class StationeryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["ID"] != null)
        {
                int stationeryID = Convert.ToInt32(Request.QueryString["ID"]);

                MsStationery stationery = StationeryHandler.GetStationeryById(stationeryID);

                
                BindStationeryData(stationery);
            }
        }

        private void BindStationeryData(MsStationery stationery)
        {
            
            gvStationeryDetails.DataSource = new List<MsStationery> { stationery };
            gvStationeryDetails.DataBind();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            int stationeryID = Convert.ToInt32(ViewState["StationeryID"]);

            
            int userID = 1;

            
            int quantity = Convert.ToInt32(txtQuantity.Text);

           
            CartHandler.CreateCart(userID, stationeryID, quantity);

            
            Response.Redirect("~/View/Home.aspx");
        }
    }
}