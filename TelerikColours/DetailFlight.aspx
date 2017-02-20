<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailFlight.aspx.cs" Inherits="TelerikColours.DetailFlight"   MasterPageFile ="~/AdminMaster.master"%>

<asp:Content ContentPlaceHolderID  ="ContentPlaceHolderAdminArea" runat ="server">
            <asp:FormView runat="server" ID="FormViewFlightDetails" ItemType ="Models.Flight" SelectMethod ="FormViewBookDetails_GetItem">
        <ItemTemplate>
            <header>
                <h1><%: Title %></h1>
                <p class="book-title"><%#: Item.Airline.Name %></p>
                <p class="book-author"><i>by <%#: Item.DateOfArrival %></i></p>
            </header>
            <div class="row-fluid">
                <div class="span12 book-description">
                    <p><%#: Item.Price %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>

