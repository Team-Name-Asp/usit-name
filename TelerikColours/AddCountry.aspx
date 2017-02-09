<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCountry.aspx.cs" Inherits="TelerikColours.AddCountry" MasterPageFile ="~/AdminMaster.master" %>



<asp:Content ContentPlaceHolderID ="ContentPlaceHolderAdminArea" runat="server">

    <label>Country name</label>
    <asp:TextBox ID ="CountryName" runat ="server"/>

    <asp:Button ID ="Submit" runat="server"  Text ="Add" OnClick ="Submit_Click"/>

</asp:Content>