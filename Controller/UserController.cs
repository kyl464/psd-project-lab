using PSDProject.Handler;
using PSDProject.Model;
using PSDProject.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static Boolean ageAtLeastOne(string dob)
        {
            DateTime today = DateTime.Now;
            DateTime birthday = DateTime.Parse(dob);

            int age = today.Year - birthday.Year;

            if (today.Month < birthday.Month || (today.Month == birthday.Month && today.Day < birthday.Day))
            {
                age--;
            }

            return age >= 1;
        }

        public static Result<MsUser> Register(string name, string gender, string dob, string phone, string address, string password, string confirm, string role)
        {
            
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(password))
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "All fields must be filled",
                    item = null
                };
            }
            if (name.Length < 5 || name.Length > 50)
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "Name must be between 5 to 50 characters",
                    item = null
                };
            }
            if (GetUser(name) != null)
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "User already exist",
                    item = null
                };
            }
            if (!IsAlphanumeric(password))
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "Password must be alphanumeric",
                    item = null
                };
            }
            if (confirm != password)
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "Password does not match",
                    item = null
                };
            }
            if (!ageAtLeastOne(dob))
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "User must be at least 1 year old",
                    item = null
                };
            }

            return new Result<MsUser>()
            {
                status = true,
                message = "Register successful",
                item = UserHandler.CreateUser(name, gender, dob, phone, address, password, role)
            };
        }

        public static Result<MsUser> Login(string username, string password, string confirm)
        {
            MsUser user = GetUser(username);
            if (user == null)
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "User not found",
                    item = null
                };
            }

            if (user.UserPassword != password)
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "Wrong Password",
                    item = null
                };
            }

            if (confirm != password)
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "Password does not match",
                    item = null
                };
            }

            return new Result<MsUser>()
            {
                status = true,
                message = "Login Successful",
                item = user
            };
        }

        public static Result<MsUser> UpdateUser(int id, string name, string gender, string dob, string phone, string address, string password, string confirm)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(password))
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "All fields must be filled",
                    item = null
                };
            }
            if (name.Length < 5 || name.Length > 50)
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "Name must be between 5 to 50 characters",
                    item = null
                };
            }
            if (GetUser(name) != null && GetUser(name).UserID != id)
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "User already exist",
                    item = null
                };
            }
            if (!IsAlphanumeric(password))
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "Password must be alphanumeric",
                    item = null
                };
            }
            if (confirm != password)
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "Password does not match",
                    item = null
                };
            }
            if (!ageAtLeastOne(dob))
            {
                return new Result<MsUser>()
                {
                    status = false,
                    message = "User must be at least 1 year old",
                    item = null
                };
            }

            return new Result<MsUser>()
            {
                status = UserHandler.UpdateUser(id, name, gender, dob, phone, address, password),
                message = "Update successful",
                item = GetUser(name)
            };
        }
    }
}
