using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication.View
{
    public partial class WebFormMonHoc : System.Web.UI.Page
    {
        string strCon = "server = ACERNITRO5\\VANDUONG; database=QLSV; Trusted_Connection=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            MonHocLoad();
        }
        private void MonHocLoad()
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                string sSql = "Select * FROM MonHoc ";
                SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection);
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                DataTable myDataTable = new DataTable();
                myDataTable.Load(mySqlDataReader);
                dgvMonHoc.DataSource = myDataTable;
                dgvMonHoc.DataBind();
            }
        }

        protected void ddlKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makhoa = ddlKhoa.SelectedValue.ToString();
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                string sSQL = "SELECT * FROM MonHoc WHERE MaKhoa = @MaKhoa ORDER BY MaMon";
                SqlCommand mySqlCommand = new SqlCommand(sSQL, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@MaKhoa", makhoa);
                mySqlConnection.Open();
                SqlDataReader sqlDataReader = mySqlCommand.ExecuteReader();
                DataTable myDataTable = new DataTable();
                myDataTable.Load(sqlDataReader);
                dgvMonHoc.DataSource = myDataTable;
                dgvMonHoc.DataBind();
            }
        }

        protected void dgvMonHoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                int row = int.Parse(e.CommandArgument.ToString());
                if (e.CommandName == "Edit")
                {
                    txbMaMon.Text = dgvMonHoc.Rows[row].Cells[0].Text;
                    txbTenMon.Text = dgvMonHoc.Rows[row].Cells[1].Text;
                    txbSoTinChi.Text = dgvMonHoc.Rows[row].Cells[2].Text;
                }
                else if (e.CommandName == "Delete")
                {
                    string s = dgvMonHoc.Rows[row].Cells[0].ToString();
                    string sSql = "DELETE FROM MonHoc WHERE MaMon = @MaMon";
                    using (SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@MaMon", s);
                        mySqlCommand.ExecuteNonQuery();
                    }
                    MonHocLoad();
                }
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không nhập mã sinh viên thì không thực hiện
            if (string.IsNullOrWhiteSpace(txbMaMon.Text))
            {
                lblMessage.Text = "Mã môn học không được để trống!";
                return;
            }

            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                try
                {
                    mySqlConnection.Open();

                    // Câu lệnh SQL dạng INSERT INTO
                    string query = "INSERT INTO dbo.MonHoc(MaMon,TenMon,SoTinChi,GhiChu,MaKhoa)VALUES(@MaMon,@TenMon,@SoTinChi,@GhiChu,@MaKhoa)";

                    using (SqlCommand mySqlCommand = new SqlCommand(query, mySqlConnection))
                    {
                        // Gán tham số cho câu truy vấn
                        mySqlCommand.Parameters.AddWithValue("@MaKhoa", dgvMonHoc.SelectedValue);
                        mySqlCommand.Parameters.AddWithValue("@TenMon", txbTenMon.Text.Trim());
                        mySqlCommand.Parameters.AddWithValue("@SoTinChi", txbSoTinChi.Text.Trim());
                        mySqlCommand.Parameters.AddWithValue("@GhiChu", txbGhiChu.Text.Trim());
                        mySqlCommand.Parameters.AddWithValue("@MaMon", txbMaMon.Text.Trim());

                        int rowsAffected = mySqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Thêm môn học thành công!";
                        }
                        else
                        {
                            lblMessage.Text = "Không thể thêm môn học!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Đã xảy ra lỗi: " + ex.Message;
                }
            }

            MonHocLoad();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();

                if (string.IsNullOrWhiteSpace(txbMaMon.Text))
                    return;
                string query = "UPDATE MonHoc SET TenMon = @TenMon, SoTinChi = @SoTinChi, GhiChu = @GhiChu WHERE MaMon = @MaMon";

                using (SqlCommand mySqlCommand = new SqlCommand(query, mySqlConnection))
                {
                    
                    mySqlCommand.Parameters.AddWithValue("@TenMon", txbTenMon.Text.Trim());
                    mySqlCommand.Parameters.AddWithValue("@SoTinChi", txbSoTinChi.Text.Trim());
                    mySqlCommand.Parameters.AddWithValue("@GhiChu", txbGhiChu.Text.Trim());
                    mySqlCommand.Parameters.AddWithValue("@MaMon", txbMaMon.Text.Trim());

                    int rowsAffected = mySqlCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Cập nhật thông tin thành công!";
                        MonHocLoad();
                    }
                    else
                    {
                        lblMessage.Text = "Không tìm thấy môn học để cập nhật!";
                    }
                }
            }
        }

        protected void dgvMonHoc_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgvMonHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}