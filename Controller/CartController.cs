using System.Collections.Generic;
using PSDProject.Handler;
using PSDProject.Model;
using PSDProject.Repository;

namespace PSDProject.Controller
{
    public class CartController
    {
        public static List<Cart> GetAllCartsByUserID(int userID)
        {
            // Logic to retrieve all cart items by userID
            return CartRepository.GetAllByUserID(userID);
        }

        public static void ClearCart(int userID)
        {
            // Logic to clear the cart
            CartRepository.ClearByUserID(userID);
        }

        public static void DeleteCart(int userID, int stationeryID)
        {
            // Logic to delete an item from the cart
            CartRepository.Delete(userID, stationeryID);
        }

        public static void UpdateCart(int userID, int stationeryID, int quantity)
        {
            CartHandler.UpdateCart(userID, stationeryID, quantity);
        }
    }
}
