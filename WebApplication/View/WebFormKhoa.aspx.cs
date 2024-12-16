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
    public partial class WebFormKhoa : System.Web.UI.Page
    {
        string strCon = "server = ACERNITRO5\\VANDUONG; database=QLSV; Trusted_Connection=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            KhoaLoad();
        }
        
        private void KhoaLoad()
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                string sSql = "Select * FROM Khoa ";
                SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection);
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                DataTable myDataTable = new DataTable();
                myDataTable.Load(mySqlDataReader);
                dgvKhoa.DataSource = myDataTable;
                dgvKhoa.DataBind();
            }
            
        }

        protected void dgvKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbMaKhoa.Text))
            {
                lblMessage.Text = "Mã khoa không được để trống!";
                txbMaKhoa.Focus();
                return;
            }

            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                try
                {
                    mySqlConnection.Open();
                    string query = "INSERT INTO Khoa (MaKhoa, TenKhoa, Phone) " +
                                   "VALUES (@MaKhoa, @TenKhoa, @Phone)";

                    using (SqlCommand mySqlCommand = new SqlCommand(query, mySqlConnection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@MaKhoa", txbMaKhoa.Text);
                        mySqlCommand.Parameters.AddWithValue("@TenKhoa", txbTenKhoa.Text);
                        mySqlCommand.Parameters.AddWithValue("@Phone", txbPhone.Text);

                        int rowsAffected = mySqlCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Thêm khoa thành công!";
                        }
                        else
                        {
                            lblMessage.Text = "Không thể thêm khoa!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Đã xảy ra lỗi: " + ex.Message;
                }
            }
            KhoaLoad();
        }

        protected void btnGhi_Click(object sender, EventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();

                // Kiểm tra nếu không nhập mã sinh viên thì dừng thực hiện
                if (string.IsNullOrWhiteSpace(txbMaKhoa.Text))
                    return;
                string query = "UPDATE Khoa SET TenKhoa = @TenKhoa, Phone = @Phone " +
                               "WHERE MaKhoa = @MaKhoa";

                using (SqlCommand mySqlCommand = new SqlCommand(query, mySqlConnection))
                {
                    mySqlCommand.Parameters.AddWithValue("@MaKhoa", txbMaKhoa.Text);
                    mySqlCommand.Parameters.AddWithValue("@TenKhoa", txbTenKhoa.Text);
                    mySqlCommand.Parameters.AddWithValue("@Phone", txbPhone.Text);

                    int rowsAffected = mySqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Cập nhật thông tin thành công!";
                    }
                    else
                    {
                        lblMessage.Text = "Không tìm thấy khoa để cập nhật!";
                    }
                }
            }
        }

        protected void dgvKhoa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                int row = int.Parse(e.CommandArgument.ToString());
                if (e.CommandName == "Edit")
                {
                    txbMaKhoa.Text = dgvKhoa.Rows[row].Cells[0].Text;
                    txbTenKhoa.Text = dgvKhoa.Rows[row].Cells[1].Text;
                    txbPhone.Text = dgvKhoa.Rows[row].Cells[2].Text;
                }
                else if (e.CommandName == "Delete")
                {
                    string sSql = "DELETE FROM Khoa WHERE MaKhoa = @MaKhoa";
                    using (SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@MaKhoa", dgvKhoa.Rows[row].Cells[0].Text);
                        int rowsAffected = mySqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Xóa thông tin thành công!";
                        }
                        else
                        {
                            lblMessage.Text = "Không tìm thấy khoa để xóa!";
                        }
                        KhoaLoad();
                    }
                }
            }
        }

        protected void dgvKhoa_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgvKhoa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}