﻿using PSDProject.Controller;
using PSDProject.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDProject.View
{
    public partial class Home : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            if (Session["userID"] != null)
            {
                Page.MasterPageFile = "~/Master/LoggedInMaster.Master";
            }
            else
            {
                Page.MasterPageFile = "~/Master/GuestMaster.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            gv_stationeries.DataSource = StationeryController.GetAllStationeries();
            gv_stationeries.DataBind();

            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["session"];
                if (cookie != null)
                {
                    SessionCookie.createSession(Session, cookie);
                }
                if (Session["userName"] == null || Session["userRole"].ToString() != "Admin")
                {
                    btn_insert.Visible = false;
                    gv_stationeries.Columns[3].Visible = false;
                }
            }
        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertStationery.aspx");
        }

        protected void gv_stationeries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hlStationeryDetails = (HyperLink)e.Row.FindControl("hlStationeryDetails");
                Label lblStationeryName = (Label)e.Row.FindControl("lblStationeryName");

                if (Session["userID"] == null || (Session["userRole"].ToString().ToString() != "Admin" && Session["userRole"].ToString() != "Customer"))
                {
                    hlStationeryDetails.Visible = false;
                    lblStationeryName.Visible = true;
                }
                else
                {
                    hlStationeryDetails.Visible = true;
                    lblStationeryName.Visible = false;
                }
            }
        }

        protected void gv_stationeries_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gv_stationeries.Rows[e.RowIndex];
            int stationeryId = int.Parse(row.Cells[0].Text);
            StationeryController.DeleteStationery(stationeryId);
            gv_stationeries.DataSource = StationeryController.GetAllStationeries();
            gv_stationeries.DataBind();

        }

        protected void gv_stationeries_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = gv_stationeries.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("~/View/UpdateStationery.aspx?id=" + id);
        }
    }
}
