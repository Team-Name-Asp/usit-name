<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TelerikColours.Profile" MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/FlightList.ascx" TagName="FlightList"
    TagPrefix="userControls" %>


<%@ Reference Control="~/FlightList.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content" style="margin-top: 100px;">
        <div class="row" style="padding-top: 20px;">
            <div class="col-md-2">
                <div class="sidebar content-box" style="display: block;">
                    <ul class="nav">
                        <li>
                            <asp:LinkButton OnClick="FlightHistory_Click" runat="server" ID="FlightHistory"><i class="glyphicon glyphicon-plus"></i> Flight history</asp:LinkButton>
                        <li>
                            <asp:LinkButton OnClick="UpFlights_Click" runat="server" ID="UpFlights"><i class="glyphicon glyphicon-plus"></i> Upcomming flights</asp:LinkButton>
                    </ul>
                </div>
            </div>
            <div class="col-md-10">
                <div class="content container-fluid">
                    <%-- <asp:EntityTemplateUserControl ID="Content" runat="server"/>--%>
                  
                        <userControls:FlightList runat="server" ID="TheFlightHistory" />
                        <userControls:FlightList runat="server" ID="UpcommingFlights" />
                 
                </div>
            </div>
        </div>
    </div>
</asp:Content>
