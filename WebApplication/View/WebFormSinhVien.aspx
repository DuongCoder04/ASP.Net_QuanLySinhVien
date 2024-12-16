<%@ Page Title="" Language="C#" MasterPageFile="~/Fontend.Master" AutoEventWireup="true" CodeBehind="WebFormSinhVien.aspx.cs" Inherits="WebApplication.View.WebFormSinhVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div> 
    TÌM KIẾM - SỬA - XÓA SINH VIÊN
    </div>
    <asp:Label ID="Label1" runat="server" Text="Khoa đào tạo"></asp:Label>
     <div>
     <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="TenKhoa" DataValueField="MaKhoa" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
     </asp:DropDownList>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:QLSVConnectionString %>" ProviderName="<%$ ConnectionStrings:QLSVConnectionString.ProviderName %>" SelectCommand="SELECT [MaKhoa], [TenKhoa] FROM [Khoa]"></asp:SqlDataSource>
 </div>
    <br>
    <asp:Label ID="Label2" runat="server" Text="Lớp BC"></asp:Label>
    <asp:TextBox ID="txbClass" runat="server"></asp:TextBox>
    <br>
    <asp:Label ID="Label3" runat="server" Text="Mã sinh viên"></asp:Label>
    <asp:TextBox ID="txbMaSV" runat="server"></asp:TextBox>
    <br>
    <asp:Label ID="Label4" runat="server" Text="Họ và tên"></asp:Label>
    <asp:TextBox ID="txbName" runat="server"></asp:TextBox>
    <br>
    <asp:Label ID="Label5" runat="server" Text="Ngày sinh"></asp:Label>
    <asp:TextBox ID="txbDate" runat="server"></asp:TextBox>
    <br>
    <asp:Label ID="Label6" runat="server" Text="Địa chỉ"></asp:Label>
    <asp:TextBox ID="txbAddress" runat="server"></asp:TextBox>
    <br>
    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Thêm" />
    <asp:Button ID="btnGhi" runat="server" Text="Cập nhật" OnClick="btnGhi_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Xóa" />
    <br>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="MaSV" HeaderText="MaSV" ReadOnly="True" SortExpression="MaSV" />
        <asp:BoundField DataField="HoTen" HeaderText="HoTen" SortExpression="HoTen" />
        <asp:BoundField DataField="DiaChi" HeaderText="DiaChi" SortExpression="DiaChi" />
        <asp:BoundField DataField="NgaySinh" HeaderText="NgaySinh" SortExpression="NgaySinh" />
        <asp:BoundField DataField="LopBC" HeaderText="LopBC" SortExpression="LopBC" />
        <asp:BoundField DataField="MaKhoa" HeaderText="MaKhoa" SortExpression="MaKhoa" />
        <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Sửa" ShowHeader="True" Text="Edit" />
        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Xóa" ShowHeader="True" Text="Delete" />
    </Columns>
</asp:GridView>
</asp:Content>
