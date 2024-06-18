using PSDProject.Controller;
using PSDProject.Model;
using PSDProject.Repository;
using System;
using System.Collections.Generic;

namespace PSDProject.Controller
{
    public class TransactionController
    {
        public static void SaveTransaction(int userID, List<Cart> cartItems)
        {
            // Create a new transaction header entry using THRepository
            var transactionHeader = THRepository.CreateTH(userID, DateTime.Now);

            // Create and save transaction items using TDRepository
            foreach (var item in cartItems)
            {
                var transactionDetail = new TransactionDetail
                {
                    TransactionID = transactionHeader.TransactionID,
                    StationeryID = item.StationeryID,
                    Quantity = item.Quantity
                };

                TDRepository.SaveDetail(transactionDetail);
            }
        }

        public static List<TransactionHeader> GetTransactionsByUserID(int userID)
        {
            return THRepository.GetTransactionsByUserID(userID);
        }

        public static List<TransactionDetail> GetTransactionDetails(int transactionID)
        {
            return TDRepository.GetTransactionDetails(transactionID);
        }
    }
}
