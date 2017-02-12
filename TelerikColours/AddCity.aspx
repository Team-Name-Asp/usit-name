<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCity.aspx.cs" Inherits="TelerikColours.AddCity" MasterPageFile="~/AdminMaster.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderAdminArea" runat="server">
    <label>Country</label>
    <asp:DropDownList ID="CountriesList" runat="server"
        DataTextField="Name"
        DataValueField="Id" />
    <label>City name</label>
    <asp:TextBox ID="CityName" runat="server" />
    <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Add" />
</asp:Content>
