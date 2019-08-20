<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="goodfood.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblResult" runat="server" Text="Label" Visible="False"></asp:Label>
<br />
<asp:Button ID="btnOk" runat="server" Text="Ok" Visible="False" Width="100px" OnClick="btnOk_Click" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False" Width="100px" OnClick="btnCancel_Click" />
<br />
<asp:Button ID="btnOrder" runat="server" Text="Order" OnClick="btnOrder_Click" />
<br />
<asp:Label ID="lblError" runat="server"></asp:Label>
<br />
<asp:Panel ID="pnlProducts" runat="server">
</asp:Panel>
<br />
<br />
</asp:Content>
