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
                if (!IsPostBack)
                {
                    HttpCookie cookie = Request.Cookies["session"];
                    if (cookie != null)
                    {
                        SessionCookie.createSession(Session, cookie);
                    }
                    if (Session["userID"] == null || Session["userRole"].ToString() != "Customer")
                    {
                        Response.Redirect("~/View/Login.aspx");
                    }
                }
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
                try
                {
                    int userID = GetLoggedInUserID();
                    int stationeryID = Convert.ToInt32(gvCart.DataKeys[row.RowIndex].Value);
                    int newQuantity = Convert.ToInt32((row.Cells[2].FindControl("txtQuantity") as TextBox).Text);

                    CartController.UpdateCart(userID, stationeryID, newQuantity);
                }
                catch (Exception ex)
                {
                    
                    Response.Write($"Kesalahan: {ex.Message}");
                }
            }

            BindCartItems();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cart Updated');", true);
        }


        protected void btnCheckout_Click(object sender, EventArgs e)
        {

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
            return StationeryController.GetStationery(stationeryID).StationeryName;
        }

        private int GetLoggedInUserID()
        {
            HttpCookie cookie = Request.Cookies["session"];
            return int.Parse(cookie["userID"]);
        }
    }
}
