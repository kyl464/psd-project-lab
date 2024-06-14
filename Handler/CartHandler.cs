using PSDProject.Model;
using PSDProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Handler
{
    public class CartHandler
    {
        public static Cart CreateCart(int id, int sid, int quantity)
        {
            return CartRepository.CreateCart(id, sid, quantity);
        }

        public static void UpdateCart(int id, int price, int quantity)
        {
            CartRepository.UpdateCart(id, price, quantity);
        }

        public static void DeleteCart(int id, int sid)
        {
            CartRepository.DeleteCart(id, sid);
        }

        public static Cart GetCart(int id,int sid)
        {
            return CartRepository.FindByID(id, sid);
        }

        public static List<Cart> GetAllCart()
        {
            return CartRepository.GetCarts().ToList();
        }
    }
}