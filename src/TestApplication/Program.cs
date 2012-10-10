using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;
using Facebook.Api;
using Youtube;
using Youtube.Api;

namespace TestApplication
{
    class
        Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2012, 10, 30, 10, 30, 00);
            var local = dt.ToLocalTime("Pacific standard time");

        }
    }
    public static class DateTimeExtensions
    {
        public static DateTime ToLocalTime(this DateTime date, string timeZone)
        {
            TimeZoneInfo timeZoneInfo;
            DateTime dateTime;
            //Set the time zone information to US Mountain Standard Time 
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            var utc = TimeZoneInfo.ConvertTimeToUtc(date, timeZoneInfo);
            var currentUtcOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            return utc.Add(currentUtcOffset);
        }

        public static DateTimeOffset ReadStringWithTimeZone(DateTime EnteredDate, TimeZoneInfo tzi)
        {
            DateTimeOffset cvUTCToTZI = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, tzi);
            DateTimeOffset cvParsedDate = DateTimeOffset.MinValue;
            DateTimeOffset.TryParse(EnteredDate + " " + cvUTCToTZI.ToString("zzz"), out cvParsedDate);
            if (tzi.SupportsDaylightSavingTime)
            {
                TimeSpan getDiff = tzi.GetUtcOffset(cvParsedDate);
                string MakeFinalOffset = (getDiff.Hours < 0 ? "-" : "+") + (getDiff.Hours > 9 ? "" : "0") + getDiff.Hours + ":" + (getDiff.Minutes > 9 ? "" : "0") + getDiff.Minutes;
                DateTimeOffset.TryParse(EnteredDate + " " + MakeFinalOffset, out cvParsedDate);
                return cvParsedDate;
            }
            else
            {
                return cvParsedDate;
            }
        }
    }
    internal class YoutubeConfig : IYoutubeConfig
    {
        public string BaseUrl { get { return "https://gdata.youtube.com/feeds/api"; } }
        public string ClientId { get { return "159997617394589"; } }
        public string Secret { get { return "ced7de09d14698199c88de1e6c2b35ad"; } }
        public string Token { get { return "159997617394589|lxqDIRGGL-6lNMVZtERkbJTNOeM"; } }
    }
}
