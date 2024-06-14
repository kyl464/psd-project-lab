using PSDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Module
{
    public class Result<T>
    {
        public Boolean status { get; set; }
        public String message { get; set; }
        public T item { get; set; }

        public Result()
        {
            this.status = status;
            this.message = message;
            this.item = item;
        }
    }
}