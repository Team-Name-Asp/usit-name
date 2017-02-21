<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailFlight.aspx.cs" Inherits="TelerikColours.DetailFlight" MasterPageFile="~/Site.master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewFlightDetails" ItemType="Models.Flight" SelectMethod="FormViewBookDetails_GetItem">
        <ItemTemplate>
            <div class="container" style="margin-top: 100px;">
                <div class="row">
                    <div class="well">
                        <div class="row">
                            <div class="col-md-5">
                                <h2><%#: Item.AirportDeparture.Name %> (<%#: Item.AirportDeparture.City.Name %>)</h2>
                            </div>
                            <div class="col-md-2">
                                <img src="/Images/flytime.png" alt="Fly time" />
                            </div>
                            <div class="col-md-5">
                                <h2><%#: Item.AirportArrival.Name %> (<%#: Item.AirportArrival.City.Name %>)  </h2>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-5" style="color: red; font-size: 45px;">
                                <%#: Item.DateOfDeparture.ToString("hh:mm") %>
                            </div>
                            <div class="col-md-2" style="color: #7BB618; font-size:30px">
                                <%#: Item.DateOfArrival - Item.DateOfDeparture %>
                            </div>
                            <div class="col-md-5" style="color: red; font-size: 45px;">
                                <%#: Item.DateOfArrival.ToString("hh:mm") %>
                            </div>
                        </div>
                        <p>
                            On: <%#: Item.DateOfDeparture.ToString("dd/MM/yyyy") %>
                        </p>
                        <p>
                            By: <%#: Item.Airline.Name %>
                        </p>
                        <p>
                            Available seats: <%#: Item.AvailableSeats %>
                        </p>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>

