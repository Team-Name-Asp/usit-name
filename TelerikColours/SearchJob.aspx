﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchJob.aspx.cs" Inherits="TelerikColours.SearchJob"
    MasterPageFile="~/Site.Master" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/Content/search-job.css" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet">
    <div id="flipkart-navbar">
        <div class="container">
            <div class="row row1">
            </div>
            <div class="row row2">
                <div class="col-sm-2">
                    <h1 style="margin: 0px; font-size: 35px;"><span class="largenav">Find Job</span></h1>
                </div>
                <div class="flipkart-navbar-search smallsearch col-sm-8 col-xs-11">
                    <div class="row">
                        <asp:TextBox ID="JobSearch" CssClass="flipkart-navbar-input col-xs-11" placeholder="Search jobs" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="SearchJobButton"
                            runat="server"
                            CssClass="flipkart-navbar-button col-xs-1"
                            OnClick="SearchJobButton_Click">
                             <span class="glyphicon glyphicon-search col-xs-1"></span>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <asp:ListView ID="JobResults" runat="server" ItemType="Models.Job" SelectMethod="JobResults_GetData">

                <ItemTemplate>
                    <div class="well" style="float: left; margin-left: 50px; margin-top: 10px; width: 500px;">
                        <div class="col-md-4">
                            <h3><%# Item.JobTitle %></h3>
                            Wage:
                            <asp:Label ID="Label5" runat="server" Text='<%# Item.Wage %>' /></p>
                        
                        Price:
                            <asp:Label ID="Label7" runat="server" Text='<%# Item.Price %>' /></p>

                            City:
                            <asp:Label ID="Label8" runat="server" Text='<%# Item.City.Name %>' />

                        </div>
                        <div class="col-md-8">
                            <img src="/Images/job-default.jpg" alt="Job" style="width: 300px; height: 150px; border-radius: 4px;" />
                        </div>

                    </div>
                </ItemTemplate>


            </asp:ListView>
        </div>
        <div class="row">
            <div class="col-md-12 col-md-offset-4">
                <asp:DataPager runat="server" PagedControlID="JobResults" ID="DataPager" PageSize="2">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btn"
                            ButtonType="Button"
                            ShowFirstPageButton="true"
                            ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="true" />
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>
            </div>
        </div>
    </div>
</asp:Content>
