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
        public static RAisoDBEntities db = DatabaseSingleton.getInstance();

        public static void CreateCart(int userID, int stationeryID, int quantity)
        {
            Cart cart = CartFactory.CreateCart(userID, stationeryID, quantity);
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public static Cart FindByID(int userID, int stationeryID)
        {
            return db.Carts.Find(userID, stationeryID);
        }
        public static void UpdateCart(int userID, int stationeryID, int quantity)
        {
            Cart cart = FindByID(userID, stationeryID);
            cart.Quantity = quantity;
        }

        public static void DeleteCart(int userID, int stationeryID)
        {
            db.Carts.Remove(FindByID(userID, stationeryID));
        }
    }
}