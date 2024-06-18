using PSDProject.Controller;
using PSDProject.Model;
using PSDProject.Module;
using PSDProject.Repository;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["session"];
            if(cookie != null)
            {
                SessionCookie.createSession(Session, cookie);
            }
            if (Session["userID"] != null)
            {
                Response.Redirect("~/View/Home.aspx");
            }

        }

        protected void Login_Button_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string password = txt_password.Text;
            string confirm = txt_confirm.Text;

            Result<MsUser> result = UserController.Login(name, password, confirm);
            lbl_error.Text = result.message;
            Boolean rememberMe = check_rememberme.Checked;

            if (rememberMe)
            {
                HttpCookie cookie = SessionCookie.createCookie(result.item.UserID.ToString(), name, result.item.UserRole);
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
            }

            if (result.status)
            {
                lbl_error.Visible = false;
                SessionCookie.createSession(Session, result.item.UserID.ToString(), name, result.item.UserRole);
                Response.Redirect("~/View/Home.aspx");
                return;
            }
        }





    }
}
