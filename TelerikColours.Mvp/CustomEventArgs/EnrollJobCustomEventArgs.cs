using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class EnrollJobCustomEventArgs : EventArgs
    {
        public EnrollJobCustomEventArgs(string userId, int jobId)
        {
            this.UserId = userId;
            this.JobId = jobId;
        }

        public string UserId { get; set; }

        public int JobId { get; set; }
    }
}
