using System;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class UserCustomEventArgs: EventArgs
    {
        public UserCustomEventArgs(string userId)
        {
            this.UserId = userId;
        }
        
        public string UserId { get; set; }
    }
}
