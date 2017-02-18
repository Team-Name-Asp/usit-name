<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TelerikColours.Home" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div class ="col-md-6"></div>
    <asp:ListView runat="server" ID="CheapestFlights" ItemType="Models.Flight">
        <LayoutTemplate>
            <div class="col-md-3 col-md-offset-2">
                <h3 class="title home-list-title">Top Users</h3>
                <div class="table-responsive">
                    <table class="table users-table">
                        <thead class="thead-inverse">
                            <tr>
                                <th>#</th>
                                <th>Departure airport</th>
                                <th>Arrival airport</th>
                                <th>Date</th>
                                <th>Price</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><a href="TicketDetails.aspx">Info</a></td>
                <td><%# Item.AirportDeparture.Name %></td>
                <td><%# Item.AirportArrival.Name %></td>
                <td><%# Item.DateOfDeparture %></td>
                <td><%# Item.Price %></td>
            </tr>

        </ItemTemplate>
    </asp:ListView>

</asp:Content>

