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
     
            Response.Redirect("~/View/Cart.aspx");
        }

        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            int userID = GetLoggedInUserID();
            var cartItems = CartController.GetAllCartsByUserID(userID);

         
            TransactionController.SaveTransaction(userID, cartItems);

            
            CartController.ClearCart(userID);

            
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
