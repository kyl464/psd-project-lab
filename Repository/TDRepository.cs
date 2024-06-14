using PSDProject.Factory;
using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Repository
{
    public class TDRepository
    {
        public static RAisoDBEntities db = DatabaseSingleton.getInstance();

        public static void CreateTD(int transactionID, int stationeryID, int quantity)
        {
            TransactionDetail transactionDetail = TDFactory.CreateTD(transactionID, stationeryID, quantity);
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();
        }
    }
}