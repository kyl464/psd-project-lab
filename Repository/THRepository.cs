using PSDProject.Factory;
using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Repository
{
    public class THRepository
    {
        public static RAisoDBEntities db = DatabaseSingleton.getInstance();

        public static TransactionHeader CreateTH(int userID, DateTime transactionDate)
        {
            TransactionHeader transactionHeader = THFactory.CreateTH(userID, transactionDate);
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();
            return transactionHeader;
        }

        public static List<TransactionHeader> GetTransactionsByUserID(int userID)
        {
            return db.TransactionHeaders
                     .Where(th => th.UserID == userID)
                     .ToList();
        }

    }
}
