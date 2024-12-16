using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace WebApplication.View
{
    public partial class WebFormDangKyHoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DangKyHocLoad();
        }

        protected void dgvDangKyHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string strCon = "server = ACERNITRO5\\VANDUONG; database=QLSV; Trusted_Connection=True";
        private void DangKyHocLoad()
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                string sSql = "Select * FROM DangKyHoc ";
                SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection);
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                DataTable myDataTable = new DataTable();
                myDataTable.Load(mySqlDataReader);
                dgvDangKyHoc.DataSource = myDataTable;
                dgvDangKyHoc.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbMaDangKy.Text))
            {
                lblMessage.Text = "Mã đăng ký không được để trống!";
                txbMaDangKy.Focus();
                return;
            }

            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                try
                {
                    mySqlConnection.Open();
                    string query = "INSERT INTO DangKyHoc (MaDangKy, MaSV, MaMon, NamHK, GhiChu) " +
                                   "VALUES (@MaDangKy, @MaSV, @MaMon, @NamHK, @GhiChu)";

                    using (SqlCommand mySqlCommand = new SqlCommand(query, mySqlConnection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@MaDangKy", txbMaDangKy.Text);
                        mySqlCommand.Parameters.AddWithValue("@MaSV", txbMaSV.Text);
                        mySqlCommand.Parameters.AddWithValue("@MaMon", txbMaMon.Text);
                        mySqlCommand.Parameters.AddWithValue("@NamHK", txbNamHK.Text);
                        mySqlCommand.Parameters.AddWithValue("@GhiChu", txbGhiChu.Text);

                        int rowsAffected = mySqlCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Thêm đăng ký học thành công!";
                        }
                        else
                        {
                            lblMessage.Text = "Không thể thêm đăng ký học!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Đã xảy ra lỗi: " + ex.Message;
                }
            }
            DangKyHocLoad();
        }

        protected void btnGhi_Click(object sender, EventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();

                // Kiểm tra nếu không nhập mã sinh viên thì dừng thực hiện
                if (string.IsNullOrWhiteSpace(txbMaDangKy.Text))
                    return;
                string query = "UPDATE DangKyHoc SET MaSV = @MaSV, MaMon = @MaMon, NamHK = @NamHK, GhiChu = @GhiChu " +
                               "WHERE MaDangKy = @MaDangKy";

                using (SqlCommand mySqlCommand = new SqlCommand(query, mySqlConnection))
                {
                    mySqlCommand.Parameters.AddWithValue("@MaDangKy", txbMaDangKy.Text);
                    mySqlCommand.Parameters.AddWithValue("@MaSV", txbMaSV.Text);
                    mySqlCommand.Parameters.AddWithValue("@MaMon", txbMaMon.Text);
                    mySqlCommand.Parameters.AddWithValue("@NamHK", txbNamHK.Text);
                    mySqlCommand.Parameters.AddWithValue("@GhiChu", txbGhiChu.Text);
                    int rowsAffected = mySqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Cập nhật thông tin thành công!";
                    }
                    else
                    {
                        lblMessage.Text = "Không tìm thấy đăng ký học để cập nhật!";
                    }
                }
            }
        }

        protected void dgvDangKyHoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                int row = int.Parse(e.CommandArgument.ToString());
                if (e.CommandName == "Edit")
                {
                    txbMaDangKy.Text = dgvDangKyHoc.Rows[row].Cells[0].Text;
                    txbMaSV.Text = dgvDangKyHoc.Rows[row].Cells[1].Text;
                    txbMaMon.Text = dgvDangKyHoc.Rows[row].Cells[2].Text;
                    txbNamHK.Text = dgvDangKyHoc.Rows[row].Cells[3].Text;
                    txbGhiChu.Text = dgvDangKyHoc.Rows[row].Cells[4].Text;
                }
                else if (e.CommandName == "Delete")
                {
                    string sSql = "DELETE FROM DangKyHoc WHERE MaDangKy = @MaDangKy";
                    using (SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@MaDangKy", dgvDangKyHoc.Rows[row].Cells[0].Text);
                        int rowsAffected = mySqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Xóa thông tin thành công!";
                        }
                        else
                        {
                            lblMessage.Text = "Không tìm thấy đăng ký học để xóa!";
                        }
                        DangKyHocLoad();
                    }
                }
            }
        }

        protected void dgvDangKyHoc_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgvDangKyHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}