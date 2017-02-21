<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketDetails.aspx.cs" Inherits="TelerikColours.TicketDetails" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5 pull-left">
                <span>Passanger count: </span>
                <asp:Label ID="PassangerCount" runat="server" />
            </div>

            <div class="col-md-5 pull-right">
                <span>Total Price </span>
                <asp:Label ID="TotalPrice" runat="server" />
            </div>
        </div>
        <div class="row">
            <asp:Label CssClass="col-md-3 pull-left" runat="server" ID="StopsCount" />
            <asp:Label CssClass="col-md-3 pull-right" runat="server" ID="Duration" />
        </div>
        <div>
            <asp:ListView runat="server" ID="Flights" ItemType="TelerikColours.Services.Models.PresentationFlight">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />

                </LayoutTemplate>

                <ItemTemplate>
                    <div class="row">
                        <span class="col-md-2">Departure: </span>
                        <span class="col-md-6"><%#: Item.AirportDepartureName + ", " +  Item.CityDepartureName + " " +  Item.DepartureDate %></span>
                    </div>
                    <div class="row">
                        <span class="col-md-2">Arrival: </span>
                        <span class="col-md-6"><%#: Item.AirportArivalName + ", " +  Item.CityArivalName + " " +  Item.ArivalDate %></span>
                    </div>
                    <div class="row">
                        <span class="col-md-2">Airline: </span>
                        <span class="col-md-6"><%# Item.AirlineName %></span>
                    </div>
                    <div class="row">
                        <span class="col-md-2">Single Price: </span>
                        <span class="col-md-6"><%# Item.Price %></span>
                        <asp:HyperLink CssClass="btn-md btn-warning" runat="server" />
                    </div>
                </ItemTemplate>
                <EmptyItemTemplate>
                    <h1>No flights found</h1>
                </EmptyItemTemplate>
                <ItemSeparatorTemplate>
                    <h1>Separate</h1>
                </ItemSeparatorTemplate>
            </asp:ListView>
            <asp:Button ID="Buy" runat="server" CssClass="button btn-success" Text="Buy" OnClick="Information_Click" />
            <asp:Label runat="server" ID="Success" />

        </div>
    </div>

</asp:Content>
