using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Custom.UploadJobImage
{
    public interface IUploadJobImageView : IView<UploadImageViewModel>
    {
        event EventHandler<UploadJobImageCustomEventArgs> UploadImage;
    }
}
