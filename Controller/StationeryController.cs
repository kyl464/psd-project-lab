using PSDProject.Handler;
using PSDProject.Model;
using PSDProject.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Controller
{
    public class StationeryController
    {
        public static Result<MsStationery> Insert(string name, int price)
        {
            Result<MsStationery> result;
            
            if(name.Length < 3 || name.Length > 50)
            {
                return result = new Result<MsStationery>()
                {
                    status = false,
                    message = "Name must be between 3 - 50 characters",
                    item = null
                };
            }

            if(price < 2000)
            {
                return result = new Result<MsStationery>()
                {
                    status = false,
                    message = "Price must be greater or equal to 2000",
                    item = null,
                };
            }

            return result = new Result<MsStationery>
            {
                status = true,
                message = "Stationery added",
                item = StationeryHandler.CreateStationery(name, price),
            };
        }

        public static List<MsStationery> GetAllStationeries()
        {
            return StationeryHandler.GetAllStationeris();
        }
    }
}