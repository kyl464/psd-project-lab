using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Factory
{
    public class THFactory
    {
        public static TransactionHeader CreateTH(int transactionID, int userId, DateTime transactionDate)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                TransactionID = transactionID,
                UserID = userId,
                TransactionDate = transactionDate
            };
            return transactionHeader;
        }
    }
}