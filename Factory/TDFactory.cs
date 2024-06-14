using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Factory
{
    public class TDFactory
    {
        public static TransactionDetail CreateTD(int transactionID, int stationeryID, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = transactionID,
                StationeryID = stationeryID,
                Quantity = quantity
            };
            return transactionDetail;
        }
    }
}