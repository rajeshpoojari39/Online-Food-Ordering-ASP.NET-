<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="MenuPage.aspx.cs" Inherits="goodfood.MenuPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Select a type:
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="menu_type" DataTextField="type" DataValueField="type" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="menu_type" runat="server" ConnectionString="<%$ ConnectionStrings:MenuDBConnectionString %>" SelectCommand="SELECT DISTINCT [type] FROM [menu] ORDER BY [type]"></asp:SqlDataSource>
</p>
<p>
    <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
</p>
</asp:Content>
