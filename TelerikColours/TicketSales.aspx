<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketSales.aspx.cs" Inherits="TelerikColours.TicketSales" MasterPageFile="~/AdminMaster.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderAdminArea" runat="server">
    <div class="row">
        <h1>Sales of Tickets for period</h1>
    </div>
    <div class="row">
        <div class="col-md-4">
            <span>Start of period</span>
            <p />
            <asp:TextBox runat="server" ID="Startdate" TextMode="Date" />
        </div>
        <div class="col-md-4">
            <span>End of period</span>
            <p />
            <asp:TextBox runat="server" ID="EndDate" TextMode="Date" />
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" ID="Submit" CssClass="btn btn-danger btn-large" OnClick="Submit_Click" Text="Check" />
        </div>
    </div>
    <asp:GridView runat="server" ID="Tickets"
        AutoGenerateColumns="false"
        ItemType="Models.Ticket"
        OnPageIndexChanging="Tickets_PageIndexChanging"
        AllowPaging="true" PageSize="2"
        SelectMethod="Tickets_GetData"
        DataKeyNames="Id"
        CssClass="table table-stripped">
        <Columns>
            <asp:BoundField DataField="BoughtDate" HeaderText="Bought date" />
            <asp:BoundField DataField="ApplicationUser.Email" HeaderText="Client email" />
            <asp:HyperLinkField DataNavigateUrlFields="FlightId" DataNavigateUrlFormatString="DetailFlight?id={0}" Text="Flight info" />
        </Columns>
    </asp:GridView>
</asp:Content>





