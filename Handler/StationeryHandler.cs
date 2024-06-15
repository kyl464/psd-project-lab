using PSDProject.Model;
using PSDProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Handler
{
    public class StationeryHandler
    {
        public static MsStationery CreateStationery(string name, int price)
        {
            return StationeryRepository.CreateStationery(name, price);
        }

        public static MsStationery UpdateStationery(int id, string name, int price)
        {
            return StationeryRepository.UpdateStationery(id, name, price);
        }

        public static void DeleteStationery(int id)
        {
            List<Cart> carts = CartHandler.GetAllCartByStationeryID(id);
            if(carts != null)
            {
                foreach(Cart cart in carts)
                {
                    CartHandler.DeleteCart(cart);
                }
            }
            StationeryRepository.DeleteStationery(id);
        }

        public static MsStationery GetStationeryByName(string name)
        {
            return StationeryRepository.FindStationeryByName(name);
        }
        public static MsStationery GetStationeryById(int stationeryID)
        {
            return StationeryRepository.FindStationeryById(stationeryID);
        }


        public static List<MsStationery> GetAllStationeris()
        {
            return StationeryRepository.GetStatoneries().ToList();
        }

    }
}