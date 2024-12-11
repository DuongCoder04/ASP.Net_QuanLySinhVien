<%@ Page Title="" Language="C#" MasterPageFile="~/Fontend.Master" AutoEventWireup="true" CodeBehind="WebFormKhoa.aspx.cs" Inherits="WebApplication.View.WebFormKhoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div> 
    TÌM KIẾM - SỬA - XÓA KHOA
</div>
<Div>
    <asp:Label ID="Label1" runat="server" Text="Khoa đào tạo"></asp:Label>
    <asp:DropDownList ID="ddlKhoa" runat="server">
    </asp:DropDownList>
</Div>
<Div>
    <asp:Button ID="btn" runat="server" Text="Ghi lại" />
</Div>
</br>
<div>
    <asp:GridView ID="dgvKhoa" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="MaKhoa" HeaderText="Mã Khoa" />
            <asp:BoundField DataField="TenKhoa" HeaderText="Tên Khoa" />
            <asp:BoundField DataField="Phone" HeaderText="Số Điện Thoại" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
