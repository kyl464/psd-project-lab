using PSDProject.Handler;
using PSDProject.Model;
using PSDProject.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;

namespace PSDProject.Controller
{
    public class UserController
    {
        public static List<MsUser> GetUsers()
        {
            return UserHandler.GetUsers();
        }

        public static MsUser GetUser(string name)
        {

            return UserHandler.GetUser(name);
        }

        public static Boolean IsAlphanumeric(string password)
        {
            foreach (char c in password)  {
                if((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')) {
                    return true;
                }
            }
            return false;
        }

        public static Boolean ageAtLeastOne(string dob)
        {
            DateTime today = DateTime.Now;
            DateTime birthday = DateTime.Parse(dob);

            int age = today.Year - birthday.Year;

            if(today.Month < birthday.Month || (today.Month == birthday.Month && today.Day < birthday.Day))
            {
                age--;
            }

            return age < 1? false : true;

        }

        public static Result<MsUser> Register(string name, string gender, string dob, string phone, string address, string password, string role)
        {
            Result<MsUser> result;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(password))
            {
                return result = new Result<MsUser>()
                {
                    status = false,
                    message = "All fields must be filled",
                    item = null
                };
            }
            if (name.Length < 5 || name.Length > 50)
            {
                return result = new Result<MsUser>()
                {
                    status = false,
                    message = "Name must be between 5 to 50 characters",
                    item = null
                };
            }
            if (UserHandler.GetUser(name) != null)
            {
                return result = new Result<MsUser>()
                {
                    status = false,
                    message = "User already exist",
                    item = null
                };
            }
            if (!IsAlphanumeric(password))
            {
                return result = new Result<MsUser>()
                {
                    status = false,
                    message = "Password must be alphanumeric",
                    item = null
                };
            }
            if (!ageAtLeastOne(dob))
            {
                return result = new Result<MsUser>()
                {
                    status = false,
                    message = "User must be at least 1 year old",
                    item = null
                };
            }

            return result = new Result<MsUser>()
            {
                status = true,
                message = "Register successful",
                item = UserHandler.CreateUser(name, gender, dob, phone, address, password, role)
            };

        }

        public static Result<MsUser> Login(string username, string password, string confirm) {

            MsUser user = GetUser(username);
            Result<MsUser> result;
            if (user == null) {
                return result = new Result<MsUser>()
                {
                    status = false,
                    message = "User not found",
                    item = user
                };
            }

            if(user.UserPassword != password) {
                return result = new Result<MsUser>()
                {
                    status = false,
                    message = "Wrong Password",
                    item = user
                };
            }

            if(confirm != password)
            {
                return result = new Result<MsUser>()
                {
                    status = false,
                    message = "Password does not match",
                    item = user
                };
            }

            return result = new Result<MsUser>()
            {
                status = true,
                message = "Login Succesful",
                item = user
            };
        }
    }
}