<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddJob.aspx.cs" Inherits="TelerikColours.Admin.AddJob" MasterPageFile ="~/AdminMaster.master" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Controls/UploadJobImage.ascx" TagPrefix="cc" TagName="UploadJobPicture" %>

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
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="Price" Text="Price:" runat="server" />
                        <asp:TextBox ID="Price" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
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
                        <asp:Label AssociatedControlID="CityList" Text="City:" runat="server" />
                        <asp:DropDownList ID="CityList" runat="server"
                            DataTextField="Name"
                            DataValueField="Id"
                             AppendDataBoundItems="true" >
                            <asp:ListItem Selected="True" Text="Select City"/>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:RadioButton ID="RadioButtonDefault" runat="server" GroupName="FileUpload" />
                            <asp:Label Text="Use default image:" AssociatedControlID="RadioButtonDefault" runat="server" />
                            <div class="row">
                                <img src="/Images/job-default.jpg" width="200" height="100" style="border-radius: 8px;" alt="default job image" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <div class="col-md-12">
                                <asp:RadioButton ID="RadioButtonCustom" runat="server" GroupName="FileUpload" />
                                <asp:Label Text="Upload your image:" AssociatedControlID="RadioButtonCustom" runat="server" />
                            </div>
                            <cc:UploadJobPicture ID="UploadJobPicture" runat="server" />
                        </div>
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
