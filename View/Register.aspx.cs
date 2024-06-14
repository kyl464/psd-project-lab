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

        }

        protected void Register_Button_Click(object sender, EventArgs e)
        {

            string name = txt_name.Text;
            string gender = radio_gender.SelectedValue;
            string dob = txt_dob.Text;
            string phone = txt_phone.Text;
            string address = txt_address.Text;
            string password = txt_password.Text;
            string role = "Customer";
            Result<MsUser> result = UserController.Register(name, gender, dob, phone, address, password, role);
            lbl_error.Text = result.message;
            Boolean rememberMe = check_rememberme.Checked;

            HttpCookie cookie = new HttpCookie("session");

            if (rememberMe)
            {
                cookie.Values["name"] = name;
                cookie.Values["role"] = result.item.UserRole;
            }

            if (result.status)
            {
                lbl_error.Visible = false;
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                Response.Redirect("~/View/Home.aspx");
                return;
            }           
        }
    }
}