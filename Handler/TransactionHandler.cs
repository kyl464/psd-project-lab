using PSDProject.Model;
using PSDProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Handler
{
    public class TransactionHandler
    {
        public static TransactionHeader CreateTH(int userID, DateTime transactionDate)
        {
            return THRepository.CreateTH(userID, transactionDate);
        }

    }
}