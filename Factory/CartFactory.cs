using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Factory
{
    public class CartFactory
    {
        public static Cart CreateCart(int userID, int stationeryID, int quantity)
        {
            Cart newCart = new Cart()
            {
                UserID = userID,
                StationeryID = stationeryID,
                Quantity = quantity
            };

            return newCart;
        }
    }
}