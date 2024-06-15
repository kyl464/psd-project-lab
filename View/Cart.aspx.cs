using PSDProject.Controller;
using PSDProject.Model;
using System;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartItems();
            }
        }

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = GetLoggedInUserID();
            int stationeryID = Convert.ToInt32(gvCart.DataKeys[e.RowIndex].Value);

            CartController.DeleteCart(userID, stationeryID);
            BindCartItems();
        }

        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCart.Rows)
            {
                int userID = GetLoggedInUserID();
                int stationeryID = Convert.ToInt32(gvCart.DataKeys[row.RowIndex].Value);
                int newQuantity = Convert.ToInt32((row.Cells[2].FindControl("txtQuantity") as TextBox).Text);

                CartController.UpdateCart(userID, stationeryID, newQuantity);
            }

            BindCartItems();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            // Redirect to checkout page or handle checkout process
            Response.Redirect("~/Checkout.aspx");
        }

        private void BindCartItems()
        {
            int userID = GetLoggedInUserID();
            gvCart.DataSource = CartController.GetAllCartsByUserID(userID);
            gvCart.DataBind();
        }

        public string GetStationeryName(int stationeryID)
        {
            return StationeryController.GetStationery(stationeryID).StationeryName;
        }
        private int GetLoggedInUserID()
        {
            // Logic to retrieve logged-in user ID, possibly from session or cookie
            return 1; // Dummy value, replace with actual logic to get user ID
        }
    }
}
