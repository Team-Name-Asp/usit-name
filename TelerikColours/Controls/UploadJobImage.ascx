<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadJobImage.ascx.cs" Inherits="TelerikColours.Controls.UploadJobImage" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-6">
                <asp:FileUpload ID="FileUploadControl" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button runat="server" ID="UploadButton" Text="Upload image" CssClass="btn btn-sm btn-success" OnClick="UploadButton_Click" />
            </div>
            <div class="col-md-6">
                <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
            </div>
        </div>
        <asp:HiddenField ID="HiddenField" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="UploadButton" />
    </Triggers>
</asp:UpdatePanel>


