using PSDProject.Controller;
using PSDProject.Model;
using PSDProject.Module;
using PSDProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["session"];
            if (cookie != null)
            {
                SessionCookie.createSession(Session, cookie);
            }
            if (Session["userID"] != null)
            {
                Response.Redirect("~/View/Home.aspx");
            }

        }

        protected void Register_Button_Click(object sender, EventArgs e)
        {

            string name = txt_name.Text;
            string gender = radio_gender.SelectedValue;
            string dob = txt_dob.Text;
            string phone = txt_phone.Text;
            string address = txt_address.Text;
            string password = txt_password.Text;
            string confirm = txt_confirm.Text;
            string role = "Customer";
            Result<MsUser> result = UserController.Register(name, gender, dob, phone, address, password, confirm, role);
            lbl_error.Text = result.message;
            Boolean rememberMe = check_rememberme.Checked;        

            if (rememberMe)
            {
                HttpCookie cookie = SessionCookie.createCookie(result.item.UserID.ToString(), name, role);
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
            }

            if (result.status)
            {
                lbl_error.Visible = false;
                SessionCookie.createSession(Session, result.item.UserID.ToString(), name, role);
                Response.Redirect("~/View/Home.aspx");
                return;
            }           
        }
    }
}