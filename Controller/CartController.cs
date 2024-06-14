using PSDProject.Handler;
using PSDProject.Model;
using PSDProject.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace PSDProject.Controller
{
    public class CartController
    {
        public static Result<Cart> Insert(int id, int sid, int quantity)
        {
            Result<Cart> result;
            
            if (quantity <= 0)
            {
                return result = new Result<Cart>()
                {
                    status = false,
                    message = "Minimum 1 Pcs",
                    item = null
                };
            }

            return result = new Result<Cart>
            {
                status = true,
                message = "Items Added to Cart",
                item = CartHandler.CreateCart(id, sid, quantity)
            };

        }
        public static List<Cart> GetAllCarts()
        {
            return CartHandler.GetAllCart();
        }
    }
}