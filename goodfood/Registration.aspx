<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="goodfood.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Username:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" EnableClientScript="False" ErrorMessage="!!! Enter Username !!!"></asp:RequiredFieldValidator>
            </td>
        </tr>
       
        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" EnableClientScript="False" ErrorMessage="!!! Enter Password !!!"></asp:RequiredFieldValidator>
            </td>
        </tr>
             
        <tr>
            <td>Confirm Password:</td>
            <td>
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirm" EnableClientScript="False" ErrorMessage="!!! Enter Confirm Passoword !!!"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirm" EnableClientScript="False" ErrorMessage="!!! Password Did Not Match !!!"></asp:CompareValidator>
            </td>
        </tr>
             
        <tr>
            <td>E-Mail:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" EnableClientScript="False" ErrorMessage="!!! Enter Email !!!"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" EnableClientScript="False" ErrorMessage="!!! Enter Valid E-Mail !!!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
             
        <tr>
            <td>
                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                <br />
                <br />
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </td>
            
        </tr>
    </table>

</asp:Content>
