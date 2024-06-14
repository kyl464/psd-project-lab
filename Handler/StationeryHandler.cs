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

        public static Boolean UpdateStationery(string name, int price)
        {
            return StationeryRepository.UpdateStationery(name, price);
        }

        public static void DeleteStationery(string name)
        {
            StationeryRepository.DeleteStationery(name);
        }

        public static MsStationery GetStationery(string name)
        {
            return StationeryRepository.FindStationeryByName(name);
        }

        public static List<MsStationery> GetAllStationeris()
        {
            return StationeryRepository.GetStatoneries().ToList();
        }

    }
}