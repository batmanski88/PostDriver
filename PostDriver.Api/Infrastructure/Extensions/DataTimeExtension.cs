using System;

namespace PostDriver.Api.Infrastructure.Extensions
{
    public static class DataTimeExtension
    {
        public static long ToTimestamp(this DateTime dateTime)
        {
            var epoch = new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc);
            var time = dateTime.Subtract(new TimeSpan(epoch.Ticks));

            return time.Ticks / 10000;
        }
    }
}