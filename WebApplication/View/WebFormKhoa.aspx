<%@ Page Title="" Language="C#" MasterPageFile="~/Fontend.Master" AutoEventWireup="true" CodeBehind="WebFormKhoa.aspx.cs" Inherits="WebApplication.View.WebFormKhoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div> 
    TÌM KIẾM - SỬA - XÓA KHOA
</div>
<Div>
    <asp:Label ID="Label1" runat="server" Text="Mã khoa"></asp:Label>
    <asp:TextBox ID="txbMaKhoa" runat="server"></asp:TextBox>
</Div>
    <Div>
    <asp:Label ID="Label2" runat="server" Text="Tên khoa"></asp:Label>
    <asp:TextBox ID="txbTenKhoa" runat="server"></asp:TextBox>
</Div>
    <Div>
    <asp:Label ID="Label3" runat="server" Text="Số điện thoại"></asp:Label>
    <asp:TextBox ID="txbPhone" runat="server"></asp:TextBox>
</Div>
<Div>
    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Thêm" />
    <asp:Button ID="btnGhi" runat="server" Text="Ghi lại" OnClick="btnGhi_Click" />
</Div>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
</br>
<div>
    <asp:GridView ID="dgvKhoa" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvKhoa_SelectedIndexChanged" OnRowCommand="dgvKhoa_RowCommand" OnRowDeleting="dgvKhoa_RowDeleting" OnRowEditing="dgvKhoa_RowEditing">
        <Columns>
            <asp:BoundField DataField="MaKhoa" HeaderText="Mã Khoa" />
            <asp:BoundField DataField="TenKhoa" HeaderText="Tên Khoa" />
            <asp:BoundField DataField="Phone" HeaderText="Số Điện Thoại" />
            <asp:CommandField ButtonType="Button" HeaderText="Sửa" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField ButtonType="Button" HeaderText="Xóa" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
