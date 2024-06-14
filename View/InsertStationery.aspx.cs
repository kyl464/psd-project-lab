﻿using PSDProject.Controller;
using PSDProject.Model;
using PSDProject.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class InsertStationery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            string name = txt_stationeryname.Text;
            int price = int.Parse(txt_stationeryprice.Text);

            Result<MsStationery> result = StationeryController.Insert(name, price);

            if(!result.status)
            {
                lbl_error.Text = result.message;
            }
            else
            {
                Response.Redirect("~/View/InsertStationery.aspx");
            }

        }
    }
}