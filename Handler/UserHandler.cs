using PSDProject.Model;
using PSDProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Handler
{
    public class UserHandler
    {
        public static MsUser CreateUser(string name, string gender, string dob, string phone, string address, string password, string role)
        {
            MsUser newUser = UserRepository.CreateUser(name, gender, dob, phone, address, password, role);
            return newUser;
        }

        public static Boolean UpdateUser(string name, string gender, string dob, string phone, string address, string password)
        {
            return UserRepository.UpdateUser(name, gender, dob, phone, address, password);
        }

        public static void DeleteUser(string username)
        {
            UserRepository.DeleteUser(username);

        }

        public static MsUser GetUser(string username)
        {
            return UserRepository.FindByName(username);
        }

        public static List<MsUser> GetUsers() 
        {
            return UserRepository.GetUsers();
        }

    } 
}