<%@ Page Title="" Language="C#" MasterPageFile="~/Fontend.Master" AutoEventWireup="true" CodeBehind="WebFormDangKyHoc.aspx.cs" Inherits="WebApplication.View.WebFormDangKyHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    TÌM KIẾM - SỬA - XÓA ĐĂNG KÝ HỌC
    <asp:Label ID="Label1" runat="server" Text="Khoa đào tạo"></asp:Label>
    <asp:DropDownList ID="ddlKhoa" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btn" runat="server" Text="Ghi lại" OnClick="btn_Click" />
    <asp:GridView ID="dgvDangKyHoc" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvDangKyHoc_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="MaDangKy" HeaderText="Mã đăng ký" />
            <asp:BoundField DataField="MaSV" HeaderText="Mã sinh viên" />
            <asp:BoundField DataField="MaMon" HeaderText="Mã môn" />
            <asp:BoundField DataField="NamHK" HeaderText="Năm học kỳ" />
            <asp:BoundField DataField="GhiChu" HeaderText="Ghi chú" />
        </Columns>
    </asp:GridView>
</asp:Content>
