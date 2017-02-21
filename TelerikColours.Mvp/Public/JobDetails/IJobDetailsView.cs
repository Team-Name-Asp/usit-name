using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.JobDetails
{
    public interface IJobDetailsView : IView<JobDetailsViewModel>
    {
        event EventHandler<JobDetailsCustomEventArgs> InitJob;

        event EventHandler<EnrollJobCustomEventArgs> EnrollJob;
    }
}
