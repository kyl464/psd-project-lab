using PSDProject.Controller;
using PSDProject.Model;
using PSDProject.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["session"];
                if (cookie != null)
                {
                    SessionCookie.createSession(Session, cookie);
                }
                if (Session["userID"] == null)
                {
                    Response.Redirect("~/View/Login.aspx");
                }
                String name = Session["userName"].ToString();
                MsUser user = UserController.GetUser(name);

                txt_name.Text = user.UserName;
                txt_gender.Text = user.UserGender;
                txt_dob.Text = user.UserDOB.Date.ToShortDateString();
                txt_phone.Text = user.UserPhone;
                txt_address.Text = user.UserAddress;
                txt_password.Text = user.UserPassword;
                txt_role.Text = user.UserRole;

            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string name = Session["userName"].ToString();
            Response.Redirect("~/View/UpdateProfile.aspx?name=" + name);
        }
    }
}