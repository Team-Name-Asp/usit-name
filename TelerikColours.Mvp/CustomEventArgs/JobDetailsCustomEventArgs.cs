using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class JobDetailsCustomEventArgs : EventArgs
    {
        public JobDetailsCustomEventArgs(int jobId)
        {
            this.JobId = jobId;
        }
        public int JobId { get; set; }
    }
}
