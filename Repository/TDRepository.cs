using PSDProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace PSDProject.Repository
{
    public class TDRepository
    {
        private static RAisoDBEntities db = DatabaseSingleton.getInstance();

        public static void SaveDetail(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();
        }

        public static List<TransactionDetail> GetTransactionDetails(int transactionID)
        {
            return db.TransactionDetails
                     .Include("MsStationery") // Include MsStationery for eager loading
                     .Where(td => td.TransactionID == transactionID)
                     .ToList();
        }
    }
}
