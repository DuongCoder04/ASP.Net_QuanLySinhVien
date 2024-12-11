<%@ Page Title="" Language="C#" MasterPageFile="~/Fontend.Master" AutoEventWireup="true" CodeBehind="WebFormMonHoc.aspx.cs" Inherits="WebApplication.View.WebFormMonHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div> 
    TÌM KIẾM - SỬA - XÓA MÔN HỌC
</div>
<Div>
    <asp:Label ID="Label1" runat="server" Text="Khoa đào tạo"></asp:Label>
    <asp:DropDownList ID="ddlKhoa" runat="server">
        <asp:ListItem>CNTT</asp:ListItem>
    </asp:DropDownList>
</Div>
</br>
<Div>
    <asp:GridView ID="dgvMonHoc" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="MaKhoa" HeaderText="Mã khoa" />
            <asp:BoundField DataField="MaMon" HeaderText="Mã Môn" />
            <asp:BoundField DataField="TenMon" HeaderText="Tên Môn" />
            <asp:BoundField DataField="SoTinChi" HeaderText="Số Tín Chỉ" />
            <asp:BoundField DataField="GhiChu" HeaderText="Ghi Chú" />
        </Columns>
    </asp:GridView>
</Div>
</asp:Content>
