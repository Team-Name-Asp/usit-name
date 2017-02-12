<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddJob.aspx.cs" Inherits="TelerikColours.AddJob" MasterPageFile="~/AdminMaster.master" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderAdminArea" runat="server">
    <div class="container">
        <asp:Label AssociatedControlID="JobDescription" Text="Job Description:" runat="server" />
        <CKEditor:CKEditorControl ID="JobDescription" BasePath="~/Scripts/ckeditor/" runat="server"></CKEditor:CKEditorControl>
    </div>
    <div class="container">
        <div class="form-inline">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="JobTitle" Text="Job Title:" runat="server" />
                        <asp:TextBox ID="JobTitle" ValidationGroup="ValidationGroupRequired" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidatorGroupRequired" runat="server"
                            ControlToValidate="JobTitle" ErrorMessage="RequiredFieldValidator"
                            ValidationGroup="ValidationGroupRequired">Required field!</asp:RequiredFieldValidator>
                    </div>
                </div>
                <%-- <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="JobDescription" Text="Job Description:" runat="server" />
                        <asp:TextBox ID="JobDescription" ValidationGroup="ValidationGroupRequired" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="JobTitle" ErrorMessage="RequiredFieldValidator"
                            ValidationGroup="ValidationGroupRequired">Required field!</asp:RequiredFieldValidator>
                    </div>
                </div>--%>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="Wage" Text="Wage ($ per hour):" runat="server" />
                        <asp:TextBox ID="Wage" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="AvailableSlots" Text="Available Slots:" runat="server" />
                        <asp:TextBox ID="AvailableSlots" TextMode="Number" min="0" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="StartDate" Text="Start Date:" runat="server" />
                        <asp:TextBox ID="StartDate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:CustomValidator runat="server"
                            ID="ValidateDateRange"
                            ControlToValidate="StartDate"
                            OnServerValidate="ValidateDateRange_ServerValidate"
                            ErrorMessage="Date must be in the future" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="EndDate" Text="End Date:" runat="server" />
                        <asp:TextBox ID="EndDate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="CompanyName" Text="Company Name:" runat="server" />
                        <asp:TextBox ID="CompanyName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="City" Text="City:" runat="server" />
                        <asp:DropDownList ID="City" runat="server"
                            DataTextField="Name"
                            DataValueField="Id" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Button ID="Submit" CssClass="btn btn-sm btn-warning" runat="server" OnClick="Submit_Click" Text="Add Job" />
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="LabelIsValid" runat="server"></asp:Label>
</asp:Content>
