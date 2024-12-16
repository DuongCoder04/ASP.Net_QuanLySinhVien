using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication.View
{
    public partial class WebFormSinhVien : System.Web.UI.Page
    {
        string strCon = "server = ACERNITRO5\\VANDUONG; database=QLSV; Trusted_Connection=True";

        protected void Page_Load(object sender, EventArgs e)
        {
             SinhVienLoad();

        }

        private void SinhVienLoad()
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                string sSQL = "SELECT * FROM SinhVien ORDER BY MaSV";
                SqlCommand mySqlCommand = new SqlCommand(sSQL, mySqlConnection);
                mySqlConnection.Open();
                SqlDataReader sqlDataReader = mySqlCommand.ExecuteReader();
                DataTable myDataTable = new DataTable();
                myDataTable.Load(sqlDataReader);
                GridView2.DataSource = myDataTable;
                GridView2.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makhoa = DropDownList1.SelectedValue.ToString();
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                string sSQL = "SELECT * FROM SinhVien WHERE MaKhoa = @MaKhoa ORDER BY MaSV";
                SqlCommand mySqlCommand = new SqlCommand(sSQL, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@MaKhoa", makhoa);
                mySqlConnection.Open();
                SqlDataReader sqlDataReader = mySqlCommand.ExecuteReader();
                DataTable myDataTable = new DataTable();
                myDataTable.Load(sqlDataReader);
                GridView2.DataSource = myDataTable;
                GridView2.DataBind();
            }
        }

        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    using (SqlConnection mySqlConnection = new SqlConnection(strCon))
        //    {
        //        mySqlConnection.Open();
        //        int row = int.Parse(e.CommandArgument.ToString());
        //        if (e.CommandName == "Edit")
        //        {
        //            txbMaSV.Text = GridView2.Rows[row].Cells[0].Text;
        //            txbName.Text = GridView2.Rows[row].Cells[1].Text;
        //            txbAddress.Text = GridView2.Rows[row].Cells[2].Text;
        //            txbDate.Text = GridView2.Rows[row].Cells[3].Text;
        //            txbClass.Text = GridView2.Rows[row].Cells[4].Text;
        //        }
        //        else if (e.CommandName == "Delete")
        //        {
        //            string s = GridView2.Rows[row].Cells[1].ToString();
        //            string sSql = "DELETE FROM SinhVien WHERE MaSV= N'" + s + "'";
        //            SqlCommand mySqlCommand = new SqlCommand(sSql,mySqlConnection);
        //            mySqlCommand.ExecuteNonQuery();
        //            DropDownList1_SelectedIndexChanged(sender, e);
        //        }
        //    }
        //}

        protected void btnGhi_Click(object sender, EventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();

                // Kiểm tra nếu không nhập mã sinh viên thì dừng thực hiện
                if (string.IsNullOrWhiteSpace(txbMaSV.Text))
                    return;
                string query = "UPDATE SinhVien SET MaKhoa = @MaKhoa, LopBC = @LopBC, HoTen = @HoTen, " +
                               "NgaySinh = @NgaySinh, DiaChi = @DiaChi WHERE MaSV = @MaSV";

                using (SqlCommand mySqlCommand = new SqlCommand(query, mySqlConnection))
                {
                    // Gán tham số cho câu truy vấn
                    mySqlCommand.Parameters.AddWithValue("@MaKhoa", DropDownList1.SelectedValue);
                    mySqlCommand.Parameters.AddWithValue("@LopBC", txbClass.Text.Trim());
                    mySqlCommand.Parameters.AddWithValue("@HoTen", txbName.Text.Trim());
                    mySqlCommand.Parameters.AddWithValue("@NgaySinh", txbDate.Text.Trim());
                    mySqlCommand.Parameters.AddWithValue("@DiaChi", txbAddress.Text.Trim());
                    mySqlCommand.Parameters.AddWithValue("@MaSV", txbMaSV.Text.Trim());

                    // Thực thi lệnh SQL
                    int rowsAffected = mySqlCommand.ExecuteNonQuery();

                    // Hiển thị thông báo nếu cần thiết
                    if (rowsAffected > 0)
                    {
                        // Ví dụ: Thông báo thành công
                        lblMessage.Text = "Cập nhật thông tin thành công!";
                    }
                    else
                    {
                        // Ví dụ: Thông báo không tìm thấy sinh viên
                        lblMessage.Text = "Không tìm thấy sinh viên để cập nhật!";
                    }
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Lấy chỉ số hàng đang chỉnh sửa
            int rowIndex = e.NewEditIndex;

            // Lấy dữ liệu từ các ô trong hàng đó
            txbMaSV.Text = GridView2.Rows[rowIndex].Cells[0].Text.Trim();
            txbName.Text = GridView2.Rows[rowIndex].Cells[1].Text.Trim();
            txbAddress.Text = GridView2.Rows[rowIndex].Cells[2].Text.Trim();
            txbDate.Text = DateTime.TryParse(GridView2.Rows[rowIndex].Cells[3].Text.Trim(), out DateTime ngaySinh)
    ? ngaySinh.ToString("dd/MM/yyyy") // Hoặc định dạng phù hợp
    : "";
            txbClass.Text = GridView2.Rows[rowIndex].Cells[4].Text.Trim();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            string maSV = GridView2.Rows[rowIndex].Cells[0].Text.Trim();

            if (string.IsNullOrEmpty(maSV))
            {
                return;
            }

            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                string sSql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                using (SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection))
                {
                    mySqlCommand.Parameters.AddWithValue("@MaSV", maSV);
                    mySqlCommand.ExecuteNonQuery();
                }
            }
            SinhVienLoad();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không nhập mã sinh viên thì không thực hiện
            if (string.IsNullOrWhiteSpace(txbMaSV.Text))
            {
                lblMessage.Text = "Mã sinh viên không được để trống!";
                return;
            }

            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                try
                {
                    mySqlConnection.Open();

                    // Câu lệnh SQL dạng INSERT INTO
                    string query = "INSERT INTO SinhVien (MaSV, MaKhoa, LopBC, HoTen, NgaySinh, DiaChi) " +
                                   "VALUES (@MaSV, @MaKhoa, @LopBC, @HoTen, @NgaySinh, @DiaChi)";

                    using (SqlCommand mySqlCommand = new SqlCommand(query, mySqlConnection))
                    {
                        // Gán tham số cho câu truy vấn
                        mySqlCommand.Parameters.AddWithValue("@MaSV", txbMaSV.Text.Trim());
                        mySqlCommand.Parameters.AddWithValue("@MaKhoa", DropDownList1.SelectedValue);
                        mySqlCommand.Parameters.AddWithValue("@LopBC", txbClass.Text.Trim());
                        mySqlCommand.Parameters.AddWithValue("@HoTen", txbName.Text.Trim());
                        mySqlCommand.Parameters.AddWithValue("@NgaySinh", txbDate.Text.Trim());
                        mySqlCommand.Parameters.AddWithValue("@DiaChi", txbAddress.Text.Trim());

                        // Thực thi lệnh SQL
                        int rowsAffected = mySqlCommand.ExecuteNonQuery();

                        // Hiển thị thông báo dựa trên kết quả
                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Thêm sinh viên thành công!";
                        }
                        else
                        {
                            lblMessage.Text = "Không thể thêm sinh viên!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi và hiển thị thông báo
                    lblMessage.Text = "Đã xảy ra lỗi: " + ex.Message;
                }
            }

            // Tải lại danh sách sinh viên nếu cần
            SinhVienLoad();
        }

    }
}
