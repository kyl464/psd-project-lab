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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string name = Request["name"];
                MsUser user = UserController.GetUser(name);
                if(!string.IsNullOrEmpty(name))
                {
                    txt_name.Text = user.UserName;
                    radio_gender.SelectedValue = user.UserGender;
                    txt_dob.Text = user.UserDOB.Date.ToShortTimeString();
                    txt_phone.Text = user.UserPhone;
                    txt_address.Text = user.UserAddress;
                }
                
            }    
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string gender = radio_gender.SelectedValue;
            string dob =  txt_dob.Text;
            string phone = txt_phone.Text;
            string address = txt_address.Text;
            string password = txt_password.Text;
            string confirm = txt_confirm.Text;
            Result<MsUser> result = UserController.UpdateUser(name, gender, dob, phone, address, password, confirm);

            if(result.status)
            {
                Response.Redirect("~/View/Profile.aspx");
            }
            else
            {
                lbl_error.Text = result.message;
            }

        }
    }
}