<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="MenuAdd.aspx.cs" Inherits="goodfood.MenuAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Add new Menu</h3>

    <table cellspacing="15" class="menuTable">
        <tr>
            <td style="width: 80px">

                Name:</td>
            <td>

                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" EnableClientScript="False" ErrorMessage="!!!Enter Name!!!"></asp:RequiredFieldValidator>

            </td>
        </tr>
       
        <tr>
            <td style="width: 80px; height: 82px;">

                Type:</td>
            <td style="height: 82px">

                <asp:TextBox ID="txtType" runat="server" Width="300px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtType" EnableClientScript="False" ErrorMessage="!!!Enter Type(&quot;Breakfast&quot;,&quot;Lunch&quot;,&quot;Dinner&quot;)!!!"></asp:RequiredFieldValidator>

            </td>
        </tr>
       
        <tr>
            <td style="width: 80px">

                Price:</td>
            <td>

                <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>

            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPrice" EnableClientScript="False" ErrorMessage="!!!Enter Price!!!"></asp:RequiredFieldValidator>

            &nbsp;</td>
        </tr>
       
        <tr>
            <td style="width: 80px">

                Image:</td>
            <td>

                <asp:DropDownList ID="ddImage" runat="server" Width="300px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddImage" EnableClientScript="False" ErrorMessage="!!! Image Not Selected !!!"></asp:RequiredFieldValidator>
                <br />
                <asp:fileupload runat="server" ID="FileUpload1"></asp:fileupload>
                <asp:button runat="server" text="Upload Image" ID="BtnUpload" OnClick="BtnUpload_Click" CausesValidation="False"  />

            </td>
        </tr>
       
       </table>

    <asp:label runat="server" text="Label" ID="lblResult"></asp:label>
    <br />

    <asp:button runat="server" text="Save" ID="btnSave" OnClick="btnSave_Click" />

</asp:Content>
