using PSDProject.Model;
using PSDProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Factory
{
    public class THFactory
    {
        public static int CreateID()
        {
            RAisoDBEntities db = DatabaseSingleton.getInstance();
            int id = 1;
            TransactionHeader last = db.TransactionHeaders.ToList().LastOrDefault();
            if (last != null)
            {
                id = db.TransactionHeaders.ToList().LastOrDefault().TransactionID;
                id++;
            }
            return id;
        }
        public static TransactionHeader CreateTH(int userId, DateTime transactionDate)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                TransactionID = CreateID(),
                UserID = userId,
                TransactionDate = transactionDate
            };
            return transactionHeader;
        }
    }
}