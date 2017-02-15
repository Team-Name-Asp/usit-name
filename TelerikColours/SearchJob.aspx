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
                    <h1 style="margin: 0px;"><span class="largenav">Find Job</span></h1>
                </div>
                <div class="flipkart-navbar-search smallsearch col-sm-8 col-xs-11">
                    <div class="row">
                        <asp:TextBox ID="JobSearch" CssClass="flipkart-navbar-input col-xs-11" placeholder="Search jobs" runat="server"></asp:TextBox>
                        <%--<input class="flipkart-navbar-input col-xs-11" type="" placeholder="Search jobs" name="">--%>
                        <ajaxToolkit:AutoCompleteExtender
                            ServiceMethod="GetAutocompleteList"
                            ServicePath="JobSearchAutocompleteService.asmx"
                            MinimumPrefixLength="2"
                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                            TargetControlID="JobSearch"
                            ID="AutoComplete1" runat="server" FirstRowSelected="false">
                        </ajaxToolkit:AutoCompleteExtender>
                        <button class="flipkart-navbar-button col-xs-1">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
