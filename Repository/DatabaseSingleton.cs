using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Repository
{
    public class DatabaseSingleton
    {
        public static RAisoDBEntities db = new RAisoDBEntities();

        public static RAisoDBEntities getInstance()
        {
            if (db == null)
            {
                db = new RAisoDBEntities();
            }
            return db;
        }
    }
}