<%@ Page Title="" Language="C#" MasterPageFile="~/Fontend.Master" AutoEventWireup="true" CodeBehind="WebFormDangKyHoc.aspx.cs" Inherits="WebApplication.View.WebFormDangKyHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    TÌM KIẾM - SỬA - XÓA ĐĂNG KÝ HỌC
    <div>
        <strong>
        <asp:Label ID="Label2" runat="server" Text="Mã đăng ký"></asp:Label>
        <asp:TextBox ID="txbMaDangKy" runat="server"></asp:TextBox>
        </strong>
    </div>
    <div>
        <strong>
            <asp:Label ID="Label3" runat="server" Text="Mã sinh viên"></asp:Label>
            <asp:TextBox ID="txbMaSV" runat="server"></asp:TextBox>
        </strong>
    </div>
    <div>
        <strong>
            <asp:Label ID="Label4" runat="server" Text="Mã môn"></asp:Label>
            <asp:TextBox ID="txbMaMon" runat="server"></asp:TextBox>
        </strong>
    </div>
    <div>
        <strong>
            <asp:Label ID="Label5" runat="server" Text="Năm học"></asp:Label>
            <asp:TextBox ID="txbNamHK" runat="server"></asp:TextBox>
        </strong>
    </div>
    <div>
        <strong>
            <asp:Label ID="Label6" runat="server" Text="Ghi chú"></asp:Label>
            <asp:TextBox ID="txbGhiChu" runat="server"></asp:TextBox>
        </strong>
    </div>
    <div>
    <asp:Button ID="btnInsert" runat="server" Text="Thêm" OnClick="btnInsert_Click" />
    <asp:Button ID="btnGhi" runat="server" Text="Ghi lại" OnClick="btnGhi_Click" />
    </div>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <asp:GridView ID="dgvDangKyHoc" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvDangKyHoc_SelectedIndexChanged" OnRowCommand="dgvDangKyHoc_RowCommand" OnRowDeleting="dgvDangKyHoc_RowDeleting" OnRowEditing="dgvDangKyHoc_RowEditing">
        <Columns>
            <asp:BoundField DataField="MaDangKy" HeaderText="Mã đăng ký" />
            <asp:BoundField DataField="MaSV" HeaderText="Mã sinh viên" />
            <asp:BoundField DataField="MaMon" HeaderText="Mã môn" />
            <asp:BoundField DataField="NamHK" HeaderText="Năm học kỳ" />
            <asp:BoundField DataField="GhiChu" HeaderText="Ghi chú" />
            <asp:CommandField ButtonType="Button" HeaderText="Sửa" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField ButtonType="Button" HeaderText="Xóa" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
