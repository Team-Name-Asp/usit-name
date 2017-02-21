﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAirport.aspx.cs" Inherits="TelerikColours.AddAirport" MasterPageFile="~/AdminMaster.master" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolderAdminArea" runat="server">
    <div class="form-group">
        <asp:UpdatePanel ID="UpdatePanelCountriesTowns" UpdateMode="Conditional"
            runat="server" class="panel">
            <ContentTemplate>

                <label>Country</label>
                <asp:DropDownList ID="CountryList"
                    runat="server"
                    DataTextField="Name"
                    DataValueField="Id"
                    AutoPostBack="true"
                    CssClass="form-control"
                    OnSelectedIndexChanged="CountryList_SelectedIndexChanged" />

                <label>City</label>
                <asp:DropDownList ID="CityList" runat="server"
                    DataTextField="Name"
                    DataValueField="Id"
                    CssClass="form-control" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <label>Airport</label>
        <asp:TextBox ID="AirportName" runat="server"
            CssClass="form-control" />

        <asp:Button ID="Submit" runat="server"
            Text="Add"
            CssClass="btn btn-md btn-success"
            OnClick="Submit_Click" />
    </div>
</asp:Content>
