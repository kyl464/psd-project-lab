using PSDProject.Controller;
using PSDProject.Handler;
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
        
        }

        protected void Btn_UpdateProfile_Click(object sender, EventArgs e)
        {
            string id = Request["UserID"];
            MsUser user = UserHandler.GetUserByID(id);
            string username = Txt_Username.Text;
            string address = Txt_Email.Text;
            string gender = RBtn_Gender.SelectedValue;
            string dob = Txt_DOB.Text;

            Result<MsUser> updatedProfile = UserHandler.checkUpdateProfile(user.UserID, username, address, gender, dob);
            if (!updatedProfile.status)
            {
                Lbl_error.Visible = true;
                Lbl_error.Text = updatedProfile.message;
                return;
            }

            Lbl_scs.Visible = true;
            Lbl_scs.Text = updatedProfile.message;
        }

        protected void btn_updatePassword_Click(object sender, EventArgs e)
        {
            string id = Request["ID"];
            MsUser x = UserHandler.GetUserByID(id);
            string newPassword = Txt_newPassword.Text;
            string confirmationPassword = Txt_confirmationPassword.Text;

            Result<MsUser> checkPassword = UserController.validateConfirmationPassword(newPassword, confirmationPassword);
            if (!checkPassword.status)
            {
                Lbl_error2.Visible = true;
                Lbl_error2.Text = checkPassword.message;
                Lbl_scs2.Visible = false;
                return;
            }

            Result<MsUser> updatePassword = UserHandler.checkUpdatePassword(x.UserID, x.UserPassword, newPassword, confirmationPassword);
            if (!updatePassword.status)
            {
                Lbl_error2.Visible = true;
                Lbl_error2.Text = updatePassword.message;
                Lbl_scs2.Visible = false;
                return;
            }

            Lbl_error2.Text = "";
            Lbl_error2.Visible = false;
            Lbl_scs2.Visible = true;
            Lbl_scs2.Text = updatePassword.message;
        }
    }
}