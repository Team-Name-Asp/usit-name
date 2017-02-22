<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAirline.aspx.cs" Inherits="TelerikColours.Admin.AddAirline" MasterPageFile ="~/AdminMaster.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderAdminArea" runat="server">
    <div class="form-group">
        <label>Airline name</label>
        <asp:TextBox ID="AirlineName" runat="server"
            CssClass="form-control" />

        <asp:Button ID="Submit" runat="server"
            Text="Add"
            CssClass="btn btn-md btn-success"
            OnClick ="Submit_Click" />
    </div>
</asp:Content>

