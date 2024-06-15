using PSDProject.Controller;
using PSDProject.Model;
using PSDProject.Module;
using System;
using System.Web;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class Cart : System.Web.UI.Page
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
                if (Session["userID"] == null || Session["userRole"].ToString() != "Customer")
                {
                    Response.Redirect("~/View/Login.aspx");
                    return;
                }
                BindCartItems();
            }
        }

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = GetLoggedInUserID();
            int stationeryID = Convert.ToInt32(gvCart.Rows[e.RowIndex].Cells[0].Text);

            CartController.DeleteCartByID(userID, stationeryID);
            BindCartItems();
        }

        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCart.Rows)
            {
                int userID = GetLoggedInUserID();
                int stationeryID = Convert.ToInt32(row.Cells[0].Text);
                int newQuantity = Convert.ToInt32((row.Cells[2].FindControl("txtQuantity") as TextBox).Text);

                CartController.UpdateCart(userID, stationeryID, newQuantity);
            }

            BindCartItems();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            // Redirect to checkout page or handle checkout process
            Response.Redirect("~/View/Checkout.aspx");
        }

        private void BindCartItems()
        {
            int userID = GetLoggedInUserID();
            gvCart.DataSource = CartController.GetAllCartsByUserID(userID);
            gvCart.DataBind();
        }

        public string GetStationeryName(int stationeryID)
        {
            return StationeryController.GetStationeryByID(stationeryID).StationeryName;
        }
        private int GetLoggedInUserID()
        {
            return int.Parse(Session["userID"].ToString());
        }
    }
}
