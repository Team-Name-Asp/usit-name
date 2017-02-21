<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TelerikColours.Profile" MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/FlightList.ascx" TagName="FlightList"
    TagPrefix="userControls" %>

<%@ Register Src="~/Controls/JobList.ascx" TagName="JobList" TagPrefix="userControls" %>

<%@ Reference Control="~/Controls/JobList.ascx" %>
<%@ Reference Control="~/FlightList.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content" style="margin-top: 100px;">
        <div class="row" style="padding-top: 20px;">
            <div class="col-md-2">
                <div class="sidebar content-box" style="display: block;">
                    <ul class="nav">
                        <li>
                            <asp:LinkButton OnClick="FlightHistory_Click" runat="server" ID="FlightHistory"><i class="glyphicon glyphicon-plus"></i> Flight history</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton OnClick="UpFlights_Click" runat="server" ID="UpFlights"><i class="glyphicon glyphicon-plus"></i> Upcomming flights</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton OnClick ="TheJobHistory_Click" runat="server" ID="TheJobHistory"><i class="glyphicon glyphicon-plus"></i> Jobs History</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton OnClick ="UpJobs_Click" runat="server" ID="UpJobs"><i class="glyphicon glyphicon-plus"></i> Upcomming jobs</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="col-md-10">
                <div class="content container-fluid">

                    <userControls:FlightList runat="server" ID="TheFlightHistory" />
                    <userControls:FlightList runat="server" ID="UpcommingFlights" />
                    <userControls:JobList runat="server" ID="JobHistory" />
                    <userControls:JobList runat="server" ID="UpcommingJobs" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
