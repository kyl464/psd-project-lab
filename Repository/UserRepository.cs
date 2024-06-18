using PSDProject.Factory;
using PSDProject.Model;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PSDProject.Repository
{
    public class UserRepository
    {
        public static RAisoDBEntities db = DatabaseSingleton.getInstance();

        public static MsUser CreateUser(string name, string gender, string dob, string phone, string address, string password, string role)
        {
            MsUser newUser = UserFactory.CreateUser(name, gender, dob, phone, address, password, role);
            db.MsUsers.Add(newUser);
            db.SaveChanges();
            return newUser;
        }

        public static MsUser FindByName(string name)
        {
            return db.MsUsers.FirstOrDefault(x => x.UserName == name);
        }

        public static MsUser FindByID(int id)
        {
            return db.MsUsers.FirstOrDefault(x => x.UserID == id);
        }

        public static bool UpdateUser(int id, string name, string gender, string dob, string phone, string address, string password)
        {
            MsUser user = FindByID(id);

            if (user != null)
            {
                user.UserName = name;
                user.UserGender = gender;
                user.UserDOB = DateTime.Parse(dob);
                user.UserPhone = phone;
                user.UserAddress = address;
                user.UserPassword = password;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static void DeleteUser(string name)
        {
            db.MsUsers.Remove(FindByName(name));
            db.SaveChanges();
        }

        public static List<MsUser> GetUsers()
        {
            return db.MsUsers.ToList();
        }
    }
}
