using PSDProject.Model;
using PSDProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Factory
{
    public class StationeryFactory
    {
        public static int CreateID()
        {
            RAisoDBEntities db = DatabaseSingleton.getInstance();
            int id = 1;
            MsStationery last = db.MsStationeries.ToList().LastOrDefault();
            if (last != null)
            {
                id = db.MsStationeries.ToList().LastOrDefault().StationeryID;
                id++;
            }
            return id;
        }

        public static MsStationery CreateStationery(string name, int price)
        {
            int newID = CreateID();
            MsStationery newStationery = new MsStationery()
            {
                StationeryID = newID,
                StationeryName = name,
                StationeryPrice = price
            };
            return newStationery;
        }
    }
}