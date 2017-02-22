<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFlight.aspx.cs" Inherits="TelerikColours.Admin.AddFlight"  MasterPageFile ="~/AdminMaster.master"%>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderAdminArea" runat="server">
    <div class="form-group">
        <asp:UpdatePanel ID="UpdatePanelCountriesTowns" UpdateMode="Conditional"
            runat="server" class="panel">
            <ContentTemplate>
                <label>Departure country</label>

                <asp:DropDownList ID ="CountryFromList"
                    runat="server"
                    DataTextField="Name"
                    DataValueField="Id"
                    AutoPostBack="true"
                    CssClass="form-control"
                    OnSelectedIndexChanged ="CountryFromList_SelectedIndexChanged"
                    AppendDataBoundItems="true">
                    <asp:ListItem Selected="true" Text="Select Country" />
                </asp:DropDownList>

                <label>Departure city</label>
                <asp:DropDownList ID="CityFromList" runat="server"
                    DataTextField="Name"
                    DataValueField="Id"
                    AutoPostBack="true"
                    CssClass="form-control"
                    OnSelectedIndexChanged="CityFromList_SelectedIndexChanged"
                    AppendDataBoundItems="true">
                    <asp:ListItem Selected="true" Text="Select City" />
                </asp:DropDownList>

                <br />
                <label>Departure airport</label>
                <asp:DropDownList ID="AirportFromList" runat="server"
                    DataTextField="Name"
                    CssClass="form-control"
                    DataValueField="Id"
                    AppendDataBoundItems="true">
                    <asp:ListItem Selected="true" Text="Select Airport" />
                </asp:DropDownList>
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
                    OnSelectedIndexChanged  ="CountryToList_SelectedIndexChanged"
                    AppendDataBoundItems="true">
                    <asp:ListItem Selected="true" Text="Select Country" />
                </asp:DropDownList>

                <br />
                <label>Arrival city</label>

                <asp:DropDownList ID="CityToList" runat="server"
                    DataTextField="Name"
                    DataValueField="Id"
                    AutoPostBack="true"
                    CssClass="form-control"
                    OnSelectedIndexChanged  ="CityToList_SelectedIndexChanged"
                    AppendDataBoundItems="true">
                    <asp:ListItem Selected="true" Text="Select City" />
                </asp:DropDownList>

                <br />
                <label>Arrival airport</label>
                <asp:DropDownList ID="AirportToList" runat="server"
                    DataTextField="Name"
                    DataValueField="Id"
                    CssClass="form-control"
                    AppendDataBoundItems="true">
                    <asp:ListItem Selected="true" Text="Select Airport" />
                </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

        <asp:DropDownList ID="AirlineList" runat="server"
            DataTextField="Name"
            DataValueField="Id"
            CssClass="form-control">
        </asp:DropDownList>

        <div>
            <span>Departure date: </span>
            <asp:TextBox ID="DateDeparture" runat="server"
                TextMode="DateTimeLocal"
                CssClass="form-control" />
        </div>

        <div>
            <span>Arrival date: </span>
            <asp:TextBox ID="ArrivalDate" runat="server"
                TextMode="DateTimeLocal"
                CssClass="form-control" />
        </div>

        <div>
            <span>Price </span>
            <asp:TextBox ID="Price" runat="server"
                TextMode="Number"
                CssClass="form-control" />
        </div>

        <div>
            <span>AvailableSeats </span>
            <asp:TextBox ID="Seats" runat="server"
                TextMode="Number"
                CssClass="form-control" />
        </div>

        <asp:Button ID="Submit" Text="Submit" runat="server" OnClick ="Submit_Click" CssClass ="btn btn-md btn-success" />
    </div>
</asp:Content>


