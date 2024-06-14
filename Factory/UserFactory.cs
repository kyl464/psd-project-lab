using PSDProject.Model;
using PSDProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Factory
{
    public class UserFactory
    {
        public static int CreateID()
        {
            RAisoDBEntities db = DatabaseSingleton.getInstance();
            int id = 1;
            MsUser lastUser = db.MsUsers.ToList().LastOrDefault();
            if (lastUser != null)
            {
                id = db.MsUsers.ToList().LastOrDefault().UserID;
                id++;
            }
            return id;
        }

        public static MsUser CreateUser(string name, string gender, string dob, string phone, string address, string password, string role)
        {
            int newID = CreateID();
            MsUser newUser = new MsUser()
            {
                UserID = newID,
                UserName = name,
                UserGender = gender,
                UserDOB = DateTime.Parse(dob),
                UserPhone = phone,
                UserAddress = address,
                UserPassword = password,
                UserRole = role
            };
            return newUser;
        }
    }
}