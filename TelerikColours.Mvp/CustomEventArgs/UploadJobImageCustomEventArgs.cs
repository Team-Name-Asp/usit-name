using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class UploadJobImageCustomEventArgs : EventArgs
    {
        public string ImageLocation { get; set; }

        public string FileName { get; set; }

        public HttpPostedFile File { get; set; }

        public UploadJobImageCustomEventArgs(string imageLocation, string fileName, HttpPostedFile file)
        {
            this.ImageLocation = imageLocation;
            this.FileName = fileName;
            this.File = file;
        }
    }
}
