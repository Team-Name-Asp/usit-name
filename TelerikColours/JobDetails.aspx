<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobDetails.aspx.cs" MasterPageFile="~/Site.Master" Inherits="TelerikColours.JobDetails" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 100px;">
        <asp:FormView runat="server" ID="FormViewJobDetails" ItemType="Models.Job" SelectMethod="FormViewJobDetails_GetItem">
            <ItemTemplate>
                <header>
                    <p class="job-image">
                        <img src="<%#: Item.ImagePath %>" alt="Job Image" style="width: 600px; height: 300px;" />
                    </p>
                    <h1 class="job-title"><%#: Item.JobTitle %></h1>
                </header>
                <div>
                    <p>
                        <%# HttpUtility.HtmlDecode(Item.JobDescription) %>
                    </p>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <p>We plan to hire: <%#: Item.Slots %> people</p>
                    </div>
                    <div class="col-md-4">
                        <p>Price: $<%#: Item.Price %></p>
                    </div>
                    <div class="col-md-4">
                        <p>Salary per hour: <%#: Item.Wage %></p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <p>Starting date: <strong><%#: Item.StartDate.ToString("dd/MM/yyyy") %></strong></p>
                    </div>
                    <div class="col-md-6">
                        <p>Ending date: <strong><%#: Item.EndDate.ToString("dd/MM/yyyy") %></strong></p>
                    </div>
                </div>
                <div>
                    <asp:Button Text="Enroll" runat="server" CssClass="btn btn-success" OnClick="EnrollJob_Click"/>
                </div>
            </ItemTemplate>
        </asp:FormView>
        <div class="back-link">
            <a href="/SearchJob">Back to job search</a>
        </div>
    </div>
</asp:Content>
