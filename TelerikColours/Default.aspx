<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TelerikColours._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 100px;">
        <div class="row">
            <div class="col-md-6">
                <img src="/Images/plane-front.jpg" alt="Flights" style="width: 550px; height: 400px; border-radius: 7px;" />
                <h2>Departing soon..</h2>
                <p>
                    If you cannot see your flight here make sure you to use search button.
                </p>
                <asp:ListView runat="server" ID="CheapestFlights" ItemType="Models.Flight">
                    <LayoutTemplate>
                        <h3>Top Offers</h3>
                        <table class="table table-responsive">
                            <thead>
                                <tr>
                                    <th></th>
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
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><a class="btn btn-sm btn-success" href="TicketDetails.aspx">Info</a></td>
                            <td><%# Item.AirportDeparture.Name %>(<%# Item.AirportDeparture.City.Name.ToUpper() %>)</td>
                            <td><%# Item.AirportArrival.Name %>(<%# Item.AirportArrival.City.Name.ToUpper() %>)</td>
                            <td><%# Item.DateOfDeparture.ToString("dd/MM/yyyy") %></td>
                            <td><%# Item.Price %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                <p>
                    <a class="btn btn-default" href="/SearchFlight">Search &raquo;</a>
                </p>
            </div>

            <div class="col-md-6">
                <img src="/Images/work-front.jpg" alt="Jobs" style="width: 550px; height: 400px; border-radius: 7px;" />
                <h2>Soonest starting job offers..</h2>
                <p>
                    If you want to search for more please use the search button.
                </p>
                <asp:ListView runat="server" ID="SoonestJobs" ItemType="Models.Job">
                    <LayoutTemplate>
                        <h3>Starting soon</h3>
                        <table class="table table-responsive">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Position</th>
                                    <th>Starting</th>
                                    <th>City</th>
                                    <th>Wage per hour</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><a class="btn btn-sm btn-success" href="JobDetails.aspx?id=<%#:Item.Id%>">Info</a></td>
                            <td><%# Item.JobTitle %></td>
                            <td><%# Item.StartDate.ToString("dd/MM/yyyy")%></td>
                            <td><%# Item.City.Name%></td>
                            <td><%# Item.Wage %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

                <p>
                    <a class="btn btn-default" href="/SearchJob">Search &raquo;</a>
                </p>
            </div>
        </div>
    </div>

</asp:Content>
