<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFlights.aspx.cs" Inherits="TelerikColours.EditFlights" MasterPageFile="~/AdminMaster.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderAdminArea" runat="server">
    <div class="form-group">
        <div class="col-md-3">
            <label for="usr">Select filter type: </label>
            <asp:ListBox runat="server" ID="FilterExpression">
                <asp:ListItem Value ="date" Text="Date"/>
                <asp:ListItem Value ="airline" Text="Airline" />
                <asp:ListItem Value = "airport" Text="Airport" />
            </asp:ListBox>
        </div>
        <div class="col-md-3">
            <asp:TextBox runat="server" ID="FilterText" CssClass="form-control" />
        </div>
        <asp:Button ID ="Submit" Text ="Search" runat ="server" CssClass ="btn btn-success" OnClick ="Submit_Click" />
    </div>

    <asp:GridView runat="server" ID="Flights"
         AutoGenerateColumns ="false"
        ItemType="Models.Flight"
        DataKeyNames="Id"
        OnPageIndexChanging="Flights_PageIndexChanging"
         AllowPaging="true" PageSize ="2"
         UpdateMethod ="Flights_UpdateItem"
         SelectMethod ="Flights_GetData">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton ="true" />
            <asp:BoundField DataField="AirportArrival.Name" HeaderText ="Arival airport" />
            <asp:BoundField DataField="DateOfArrival" HeaderText ="Arival date" />
            <asp:BoundField DataField="AirportDeparture.Name" HeaderText ="Departure airport" />
            <asp:BoundField DataField="DateOfDeparture" HeaderText ="Departure date" />
            <asp:BoundField DataField="AvailableSeats" HeaderText ="Available seats" />
            <asp:BoundField DataField="Price" HeaderText ="Price" />
        </Columns>
    </asp:GridView>
</asp:Content>

