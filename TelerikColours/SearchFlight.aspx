<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchFlight.aspx.cs" Inherits="TelerikColours.SearchFlight" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class ="row">
        <h1>Fuck CSs    </h1>
    </div>
    <div class="row">
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
                        CssClass="form-control">
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
                        CssClass="form-control">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />

            <div>
                <span>Departure date: </span>
                <asp:TextBox ID="DateDeparture" runat="server"
                    TextMode="DateTimeLocal"
                    CssClass="form-control" />
            </div>

            <div>
                <span>Return date: </span>
                <asp:TextBox ID="ArrivalDate" runat="server"
                    TextMode="DateTimeLocal"
                    CssClass="form-control" />
            </div>

            <asp:Button ID="Submit" Text="Submit" runat="server" OnClick="Submit_Click" CssClass="btn btn-md btn-success" />
        </div>
    </div>

</asp:Content>

