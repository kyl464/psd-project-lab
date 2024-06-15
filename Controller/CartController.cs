using PSDProject.Handler;
using PSDProject.Model;
using PSDProject.Module;
using System.Collections.Generic;

namespace PSDProject.Controller
{
    public class CartController
    {
        public static Result<Cart> Insert(int userID, int stationeryID, int quantity)
        {
            if (quantity <= 0)
            {
                return new Result<Cart>()
                {
                    status = false,
                    message = "Quantity must be at least 1",
                    item = null
                };
            }

            Cart cart = CartHandler.CreateOrUpdateCart(userID, stationeryID, quantity);
            return new Result<Cart>()
            {
                status = true,
                message = "Item added to cart successfully",
                item = cart
            };
        }

        public static List<Cart> GetAllCarts()
        {
            return CartHandler.GetAllCart();
        }

        public static List<Cart> GetAllCartsByUserID(int userID)
        {
            return CartHandler.GetAllCartByUserID(userID);
        }

        public static List<Cart> GetAllCartsByStationeryID(int stationeryID)
        {
            return CartHandler.GetAllCartByStationeryID(stationeryID);
        }

        public static void UpdateCart(int userID, int stationeryID, int quantity)
        {
            CartHandler.UpdateCart(userID, stationeryID, quantity);
        }

        public static void DeleteCart(int userID, int stationeryID)
        {
            CartHandler.DeleteCart(userID, stationeryID);
        }

        public static void DeleteCartByStationeryID(int stationeryID)
        {
           
        }
    }
}
