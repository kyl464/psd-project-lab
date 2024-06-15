using PSDProject.Handler;
using PSDProject.Model;
using PSDProject.Module;
using PSDProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Controller
{
    public class StationeryController
    {

        public static Result<MsStationery> ValidateInput(string name, int price)
        {
            if (name.Length < 3 || name.Length > 50)
            {
                return new Result<MsStationery>()
                {
                    status = false,
                    message = "Name must be between 3 - 50 characters",
                    item = null
                };
            }

            if (price < 2000)
            {
                return new Result<MsStationery>()
                {
                    status = false,
                    message = "Price must be greater or equal to 2000",
                    item = null,
                };
            }
            return new Result<MsStationery>()
            {
                status = true,
            };
        }
        public static Result<MsStationery> Insert(string name, int price)
        {
            ValidateInput(name, price);

            return new Result<MsStationery>
            {
                status = true,
                message = "Update successful",
                item = StationeryHandler.CreateStationery(name, price),
            };
        }

        public static Result<MsStationery> UpdateStationery(int id, string name, int price)
        {
            ValidateInput(name, price);
            if (name.Length < 3 || name.Length > 50)
            {
                return new Result<MsStationery>()
                {
                    status = false,
                    message = "Name must be between 3 - 50 characters",
                    item = null
                };
            }

            if (price < 2000)
            {
                return new Result<MsStationery>()
                {
                    status = false,
                    message = "Price must be greater or equal to 2000",
                    item = null,
                };
            }
            return new Result<MsStationery>()
            {
                status = true,
                message = "Update successful",
                item = StationeryHandler.UpdateStationery(id, name, price)
            };
        }
        public static void DeleteStationery(int id)
        {
            StationeryHandler.DeleteStationery(id);
        }

        public static List<MsStationery> GetAllStationeries()
        {
            return StationeryHandler.GetAllStationeris();
        }

        public static MsStationery GetStationeryByID(int id)
        {
            return StationeryHandler.GetStationeryById(id);
        }
    }
}