using PSDProject.Factory;
using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace PSDProject.Repository
{
    public class THRepository
    {
        public static RAisoDBEntities db = DatabaseSingleton.getInstance();

        public static void CreateTH(int transactionID, int userID, DateTime transactionDate)
        {
            TransactionHeader transactionHeader = THFactory.CreateTH(transactionID, userID, transactionDate);
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();
        }

        
    }
}