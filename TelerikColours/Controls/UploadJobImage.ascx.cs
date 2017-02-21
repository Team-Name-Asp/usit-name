﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TelerikColours.Mvp.Custom.UploadJobImage;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours.Controls
{
    [PresenterBinding(typeof(UploadJobImagePresenter))]
    public partial class UploadJobImage : MvpUserControl<UploadImageViewModel>, IUploadJobImageView
    {
        public string HiddenInputValue
        {
            get
            {
                return this.HiddenField.Value;
            }
            set
            {
                this.HiddenInputValue = this.HiddenField.Value;
            }
        }

        public event EventHandler<UploadJobImageCustomEventArgs> UploadImage;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            //var fileName = this.FileUploadControl.PostedFile.FileName;
            var fileName = Guid.NewGuid().ToString() + ".png";
            var imageLocation = "/Images/" + fileName;
            var file = this.FileUploadControl.PostedFile;

            this.UploadImage?.Invoke(sender, new UploadJobImageCustomEventArgs(imageLocation, fileName, file));

            this.StatusLabel.Text = this.Model.SuccessMessage != null ? this.Model.SuccessMessage : this.Model.ErrorMessage;
            this.HiddenField.Value = this.Model.FilePath;
            this.StatusLabel.DataBind();
        }
    }
}