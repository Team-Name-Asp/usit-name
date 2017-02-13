<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchFlight.aspx.cs" Inherits="TelerikColours.SearchFlight" MasterPageFile="~/Site.Master" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1>Fuck CSs    </h1>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanelCountriesTowns" UpdateMode="Conditional"
                    runat="server" class="panel">
                    <ContentTemplate>
                        <label>Departure country</label>

                        <asp:DropDownList ID="CountryFromList"
                            runat="server"
                            DataTextField="Name"
                            DataValueField="Id"
                            AutoPostBack="true"
                            CssClass="form-control"
                            OnSelectedIndexChanged="CountryFromList_SelectedIndexChanged">
                        </asp:DropDownList>

                        <label>Departure city</label>
                        <asp:DropDownList ID="CityFromList" runat="server"
                            DataTextField="Name"
                            DataValueField="Id"
                            AutoPostBack="true"
                            CssClass="form-control"
                            OnSelectedIndexChanged="CityFromList_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <label>Departure airport</label>
                        <asp:DropDownList ID="DepartureAirport" runat="server"
                            DataTextField="Name"
                            CssClass="form-control"
                            DataValueField="Id">
                        </asp:DropDownList>

                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional"
                    runat="server" class="panel">
                    <ContentTemplate>
                        <label>Arrival country</label>

                        <asp:DropDownList ID="CountryToList" runat="server"
                            DataTextField="Name"
                            DataValueField="Id"
                            AutoPostBack="true"
                            CssClass="form-control"
                            OnSelectedIndexChanged="CountryToList_SelectedIndexChanged">
                        </asp:DropDownList>

                        <br />
                        <label>Arrival city</label>

                        <asp:DropDownList ID="CityToList" runat="server"
                            DataTextField="Name"
                            DataValueField="Id"
                            AutoPostBack="true"
                            CssClass="form-control"
                            OnSelectedIndexChanged="CityToList_SelectedIndexChanged">
                        </asp:DropDownList>

                        <br />
                        <label>Arival airport</label>
                        <asp:DropDownList ID="ArivalAirport" runat="server"
                            DataTextField="Name"
                            CssClass="form-control"
                            DataValueField="Id">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>


                <div>
                    <span>Departure date: </span>
                    <asp:TextBox ID="DateDeparture" runat="server"
                        TextMode="Date"
                        CssClass="form-control" />
                </div>

                <div>
                    <span>Passangers count: </span>
                    <asp:TextBox ID="Count" runat="server"
                        TextMode="Number"
                        CssClass="form-control" />
                </div>

                <div>
                </div>
                <asp:Button ID="Submit" Text="Submit" runat="server" OnClick="Submit_Click" CssClass="btn btn-md btn-success" />
            </div>
        </div>
        <div class="col-lg-6">

            <div class="row">
                <span class="col-md-3 pull-left" id="LabelTotalPrice" runat="server"></span>

                <span id="TotalPrice" runat="server" class="col-md-3 pull-right"></span>
            </div>
            <asp:ListView runat="server" ID="Flights" ItemType="TelerikColours.Services.Models.PresentationFlight">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    <asp:HyperLink runat="server" NavigateUrl ="~/TicketDetails.aspx" CssClass="button btn-success">More Info</asp:HyperLink>
                </LayoutTemplate>

                <ItemTemplate>
                    <div class="row">
                        <span class="col-md-2"><%#: Item.AirlineName %></span>
                        <div class="col-md-3">
                            <span><%#: Item.AirportDepartureName %></span>
                        </div>
                        </br>
                       <span><%#: Item.AirportArivalName %></span>
                    </div>
                </ItemTemplate>
                <EmptyItemTemplate>
                    <h1>No flights found</h1>
                </EmptyItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>

