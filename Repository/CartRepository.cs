using PSDProject.Factory;
using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Repository
{
    public class CartRepository
    {
        private static RAisoDBEntities db = DatabaseSingleton.getInstance();

        public static List<Cart> GetCarts()
        {
            return db.Carts.ToList();
        }

        public static List<Cart> GetCartsByUserID(int userID)
        {
            return db.Carts.Where(c => c.UserID == userID).ToList();
        }

        public static List<Cart> GetCartsByStationeryId(int stationeryID)
        {
            return db.Carts.Where(cart => cart.StationeryID == stationeryID).ToList();
        }

        public static Cart CreateCart(int userID, int stationeryID, int quantity)
        {
            var existingCart = db.Carts.FirstOrDefault(c => c.UserID == userID && c.StationeryID == stationeryID);

            if (existingCart != null)
            {
                existingCart.Quantity += quantity;
            }
            else
            {
                // Check if stationeryID exists in MsStationeries table
                var stationery = db.MsStationeries.Find(stationeryID);
                if (stationery == null)
                {
                    throw new Exception($"The specified stationeryID: {stationeryID} does not exist in the MsStationery table.");
                }

                // Check if userID exists in MsUsers table
                var user = db.MsUsers.Find(userID);
                if (user == null)
                {
                    throw new Exception($"The specified userID: {userID} does not exist in the MsUser table.");
                }

                Cart cart = CartFactory.CreateCart(userID, stationeryID, quantity);
                db.Carts.Add(cart);
            }

            db.SaveChanges();
            return db.Carts.FirstOrDefault(c => c.UserID == userID && c.StationeryID == stationeryID);
        }

        public static void UpdateCart(int userID, int stationeryID, int quantity)
        {
            Cart cart = FindByID(userID, stationeryID);
            if (cart != null)
            {
                cart.Quantity = quantity;
                db.SaveChanges();
            }
        }

        public static void DeleteCartByID(int userID, int stationeryID)
        {
            Cart cart = FindByID(userID, stationeryID);
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
        }

        public static void DeleteCart(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public static Cart FindByID(int userID, int stationeryID)
        {
            return db.Carts.Find(userID, stationeryID);
        }
    }
}
