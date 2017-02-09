using System;

namespace TelerikColours.Services.Utils
{
    public class DefaultTimeProvider : TimeProvider
    {
        public override DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}
