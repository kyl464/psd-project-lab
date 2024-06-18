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

            return CartRepository.GetAllByUserID(userID);
        }

        public static void ClearCart(int userID)
        {
            
            CartRepository.ClearByUserID(userID);
        }

        public static void DeleteCart(int userID, int stationeryID)
        {
            
            CartRepository.Delete(userID, stationeryID);
        }

        public static void UpdateCart(int userID, int stationeryID, int quantity)
        {
            CartHandler.UpdateCart(userID, stationeryID, quantity);
        }
    }
}
