<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FlightList.ascx.cs" Inherits="TelerikColours.FlightHistory" ClassName="MyUserControl" %>

<asp:UpdatePanel ID="UpdatePanelCountriesTowns" UpdateMode="Conditional"
    runat="server" class="panel">

    <ContentTemplate>
        <div class="row">
            <asp:Label runat="server" ID="Type" />
        </div>
        <div class="row">

            <asp:ListView runat="server" ID="Flights" ItemType="Models.Flight">
                <LayoutTemplate>
                    <span runat="server" id="itemPlaceholder"></span>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="row">
                        <div class="well" style="float: left; margin-left: 50px; margin-top: 10px; width: 1000px;">
                            <div class="col-md-4">
                                <h3>Departure</h3>
                                Airport:
                            <asp:Label ID="Label5" runat="server" Text='<%# Item.AirportDeparture.Name %>' /></p>
                        
                        Date:
                            <asp:Label ID="Label7" runat="server" Text='<%# Item.DateOfDeparture %>' /></p>
                            </div>
                            <div class="col-md-4">
                                <h3>Arrival</h3>
                                Airport:
                            <asp:Label ID="Label1" runat="server" Text='<%# Item.AirportArrival.Name %>' /></p>
                        Date:
                            <asp:Label ID="Label2" runat="server" Text='<%# Item.DateOfArrival %>' /></p>
                            </div>
                            <div class="col-md-4">
                                <h3>Price</h3>
                                <asp:Label ID="Label3" runat="server" Text='<%# Item.Price %>' /></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:ListView>
        </div>
        </ContentTemplate>
</asp:UpdatePanel>