﻿using System;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Custom.UploadJobImage
{
    public class UploadJobImagePresenter : Presenter<IUploadJobImageView>
    {
        public UploadJobImagePresenter(IUploadJobImageView view) : base(view)
        {
            this.View.UploadImage += View_UploadImage;
        }

        private void View_UploadImage(object sender, UploadJobImageCustomEventArgs e)
        {
            var uploadedFile = e.File;
            var fileName = e.FileName;
            var path = e.ImageLocation;

            try
            {
                if (uploadedFile.ContentType == "image/jpeg" 
                    || uploadedFile.ContentType == "image/jpg"
                    || uploadedFile.ContentType == "image/png")
                {
                    if (uploadedFile.ContentLength < (102400 * 2))
                    {
                        try
                        {
                            // string filename = Path.GetFileName(uploadedFile.FileName);
                            uploadedFile.SaveAs(Server.MapPath(path));
                            this.View.Model.SuccessMessage = "Upload status: File uploaded!";
                            this.View.Model.FilePath = path;
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }

                    }
                    else
                    {
                        this.View.Model.ErrorMessage = "Upload status: The file has to be less than 100 kb!";
                    }
                }
                else
                {
                    this.View.Model.ErrorMessage = "Upload status: Only image files are accepted!";
                }
            }

            catch (Exception ex)
            {
                var text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
}
