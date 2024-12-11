﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.View
{
    public partial class WebFormMonHoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            KhoaDDList();
            MonHocLoad();
        }
        string strCon = "server = ACERNITRO5\\VANDUONG; database=QLSV; Trusted_Connection=True";
        SqlConnection mySqlConnection;
        SqlCommand mySqlCommand;
        private void MonHocLoad()
        {
            mySqlConnection = new SqlConnection(strCon);
            mySqlConnection.Open();
            string sSql = "Select * FROM MonHoc ";
            mySqlCommand = new SqlCommand(sSql, mySqlConnection);
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            DataTable myDataTable = new DataTable();
            myDataTable.Load(mySqlDataReader);
            dgvMonHoc.DataSource = myDataTable;
            dgvMonHoc.DataBind();
        }
        private void KhoaDDList()
        {
            mySqlConnection = new SqlConnection(strCon);
            mySqlConnection.Open();
            string sSql = "Select * FROM Khoa ";
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSql, mySqlConnection);
            DataTable dt = new DataTable();
            myDataAdapter.Fill(dt);
            ddlKhoa.DataSource = dt;
            ddlKhoa.DataBind();
            ddlKhoa.DataTextField = "TenKhoa";
            ddlKhoa.DataValueField = "MaKhoa";
            ddlKhoa.DataBind();
        }
    }
}