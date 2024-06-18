using System;
using System.Web;
using System.Web.UI;
using PSDProject.Controller;
using PSDProject.Model;

namespace PSDProject.View
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartItems();
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            // Redirect to cart page or previous page
            Response.Redirect("~/View/Cart.aspx");
        }

        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            int userID = GetLoggedInUserID();
            var cartItems = CartController.GetAllCartsByUserID(userID);

            // Save transaction
            TransactionController.SaveTransaction(userID, cartItems);

            // Clear the cart after checkout
            CartController.ClearCart(userID);

            // Show Thank You message and redirect to home page
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Thank You for Shopping'); window.location='Home.aspx';", true);
        }

        private void BindCartItems()
        {
            int userID = GetLoggedInUserID();
            gvCart.DataSource = CartController.GetAllCartsByUserID(userID);
            gvCart.DataBind();
        }

        private int GetLoggedInUserID()
        {
            HttpCookie cookie = Request.Cookies["session"];
            return int.Parse(cookie["userID"]);
        }
    }
}
