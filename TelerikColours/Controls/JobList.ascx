<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobList.ascx.cs" Inherits="TelerikColours.Controls.JobList" %>

<div class="row">
    <asp:Label runat="server" ID="Type" />
</div>
<div class="row">

    <asp:ListView runat="server" ID="JobsLV" ItemType="Models.Job">
        <LayoutTemplate>
            <span runat="server" id="itemPlaceholder"></span>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="well" style="float: left; margin-left: 50px; margin-top: 10px; width: 1000px;">
                    <div class="col-md-4">
                        <h3>Departure</h3>
                        Airport:
                            <asp:Label ID="Label5" runat="server" Text='<%# Item.JobTitle %>' /></p>
                        
                        Date:
                            <asp:Label ID="Label7" runat="server" Text='<%# Item.CompanyName %>' /></p>
                    </div>
                    <div class="col-md-4">
                        <h3>Arrival</h3>
                        Date:
                            <asp:Label ID="Label1" runat="server" Text='<%# Item.StartDate %>' /></p>
                        Date:
                            <asp:Label ID="Label2" runat="server" Text='<%# Item.EndDate %>' /></p>
                    </div>
                    <div class="col-md-4">
                        <h3>Price</h3>
                        <asp:Label ID="Label3" runat="server" Text='<%# Item.Price %>' /></p>
                                <asp:Label ID="Label4" runat="server" Text='<%# Item.Wage %>' /></p>
                    </div>
                </div>
            </div>
        </ItemTemplate>

    </asp:ListView>
</div>
