<%@ Page Title="" Language="C#" MasterPageFile="~/Fontend.Master" AutoEventWireup="true" CodeBehind="WebFormMonHoc.aspx.cs" Inherits="WebApplication.View.WebFormMonHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div> 
    TÌM KIẾM - SỬA - XÓA MÔN HỌC
    </div>
    <Div>
        <asp:Label ID="Label1" runat="server" Text="Khoa đào tạo"></asp:Label>
        <asp:DropDownList ID="ddlKhoa" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="TenKhoa" DataValueField="MaKhoa" OnSelectedIndexChanged="ddlKhoa_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:QLSVConnectionString %>" SelectCommand="SELECT [MaKhoa], [TenKhoa] FROM [Khoa]"></asp:SqlDataSource>
    </Div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Mã môn"></asp:Label>
        <asp:TextBox ID="txbMaMon" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Tên môn"></asp:Label>
        <asp:TextBox ID="txbTenMon" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Số tín chỉ"></asp:Label>
        <asp:TextBox ID="txbSoTinChi" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="Ghi chú"></asp:Label>
        <asp:TextBox ID="txbGhiChu" runat="server"></asp:TextBox>
        <br>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </div>
        <asp:Button ID="btnInsert" runat="server" Text="Thêm" OnClick="btnInsert_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click" />
    </br>
    <Div>
        <asp:GridView ID="dgvMonHoc" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvMonHoc_RowCommand" OnRowDeleting="dgvMonHoc_RowDeleting" OnRowEditing="dgvMonHoc_RowEditing">
            <Columns>
                <asp:BoundField DataField="MaMon" HeaderText="Mã Môn" />
                <asp:BoundField DataField="TenMon" HeaderText="Tên Môn" />
                <asp:BoundField DataField="SoTinChi" HeaderText="Số Tín Chỉ" />
                <asp:BoundField DataField="GhiChu" HeaderText="Ghi Chú" />
                <asp:BoundField DataField="MaKhoa" HeaderText="Mã Khoa" />
                <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Sửa" ShowHeader="True" Text="Edit" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Xóa" ShowHeader="True" Text="Delete" />
            </Columns>
        </asp:GridView>
    </Div>
</asp:Content>
