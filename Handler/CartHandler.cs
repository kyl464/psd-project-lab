using PSDProject.Model;
using PSDProject.Repository;
using System.Collections.Generic;

namespace PSDProject.Handler
{
    public class CartHandler
    {
        public static Cart CreateOrUpdateCart(int userID, int stationeryID, int quantity)
        {
            return CartRepository.CreateCart(userID, stationeryID, quantity);
        }

        public static void UpdateCart(int userID, int stationeryID, int quantity)
        {
            CartRepository.UpdateCart(userID, stationeryID, quantity);
        }

        public static void DeleteCartByID(int userID, int stationeryID)
        {
            CartRepository.DeleteCartByID(userID, stationeryID);
        }

        public static void DeleteCart(Cart cart)
        {
            CartRepository.DeleteCart(cart);
        }

        public static Cart GetCart(int userID, int stationeryID)
        {
            return CartRepository.FindByID(userID, stationeryID);
        }

        public static List<Cart> GetAllCart()
        {
            return CartRepository.GetCarts();
        }

        public static List<Cart> GetAllCartByUserID(int userID)
        {
            return CartRepository.GetCartsByUserID(userID);
        }

        public static List<Cart> GetAllCartByStationeryID(int stationeryID)
        {
            return CartRepository.GetCartsByStationeryId(stationeryID);
        }

        
    }
}
