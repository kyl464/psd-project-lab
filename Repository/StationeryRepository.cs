using PSDProject.Factory;
using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Repository
{
    public class StationeryRepository
    {
        static RAisoDBEntities db = DatabaseSingleton.getInstance();

        public static List<MsStationery> GetStatoneries()
        {
            return db.MsStationeries.ToList();
        }

        public static MsStationery CreateStationery(string name, int price)
        {
            MsStationery newStationery = StationeryFactory.CreateStationery(name, price);
            db.MsStationeries.Add(newStationery);
            db.SaveChanges();
            return newStationery;
        }

        public static MsStationery FindStationeryByName(string name)
        {
            MsStationery msStationery = db.MsStationeries.Where(x => x.StationeryName == name).FirstOrDefault();
            return msStationery;
        }

        public static MsStationery UpdateStationery(int id, string name, int price)
        {
            MsStationery msStationery = FindStationeryById(id);
            if(msStationery != null)
            {
                msStationery.StationeryName = name;
                msStationery.StationeryPrice = price;
                db.SaveChanges();
                return msStationery;
            }
            
            return null;
        }
        public static MsStationery FindStationeryById(int stationeryID)
        {
            MsStationery msStationery = db.MsStationeries.Find(stationeryID);
            return msStationery;
        }


        public static void DeleteStationery(int id)
        {

            db.MsStationeries.Remove(FindStationeryById(id));
            db.SaveChanges();
        }

    }
}