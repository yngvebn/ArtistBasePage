using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace ArtistBasePage.Infrastructure
{
    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value) where T : struct, IConvertible
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                throw new InvalidDataException(string.Format("{0} is not a valid option for {1}", value, typeof(T).Name));
            }
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime ToLocalTime(this DateTime date, string timeZone)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            var utc = TimeZoneInfo.ConvertTimeToUtc(date, timeZoneInfo);
            var currentUtcOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            var adjusted = utc.Add(currentUtcOffset);
            var returnDate = new DateTime(adjusted.Year, adjusted.Month, adjusted.Day, adjusted.Hour, adjusted.Minute, adjusted.Second);
            
            return returnDate;
        }

    }

    public static class TimeZones
    {
        public const string MoroccoStandardTime = "Morocco Standard Time";
        public const string GMTStandardTime = "GMT Standard Time";
        public const string GreenwichStandardTime = "Greenwich Standard Time";
        public const string WEuropeStandardTime = "W. Europe Standard Time";
        public const string CentralEuropeStandardTime = "Central Europe Standard Time";
        public const string RomanceStandardTime = "Romance Standard Time";
        public const string CentralEuropeanStandardTime = "Central European Standard Time";
        public const string WCentralAfricaStandardTime = "W. Central Africa Standard Time";
        public const string JordanStandardTime = "Jordan Standard Time";
        public const string GTBStandardTime = "GTB Standard Time";
        public const string MiddleEastStandardTime = "Middle East Standard Time";
        public const string EgyptStandardTime = "Egypt Standard Time";
        public const string SouthAfricaStandardTime = "South Africa Standard Time";
        public const string FLEStandardTime = "FLE Standard Time";
        public const string IsraelStandardTime = "Israel Standard Time";
        public const string EEuropeStandardTime = "E. Europe Standard Time";
        public const string NamibiaStandardTime = "Namibia Standard Time";
        public const string ArabicStandardTime = "Arabic Standard Time";
        public const string ArabStandardTime = "Arab Standard Time";
        public const string RussianStandardTime = "Russian Standard Time";
        public const string EAfricaStandardTime = "E. Africa Standard Time";
        public const string GeorgianStandardTime = "Georgian Standard Time";
        public const string IranStandardTime = "Iran Standard Time";
        public const string ArabianStandardTime = "Arabian Standard Time";
        public const string AzerbaijanStandardTime = "Azerbaijan Standard Time";
        public const string MauritiusStandardTime = "Mauritius Standard Time";
        public const string CaucasusStandardTime = "Caucasus Standard Time";
        public const string AfghanistanStandardTime = "Afghanistan Standard Time";
        public const string EkaterinburgStandardTime = "Ekaterinburg Standard Time";
        public const string PakistanStandardTime = "Pakistan Standard Time";
        public const string WestAsiaStandardTime = "West Asia Standard Time";
        public const string IndiaStandardTime = "India Standard Time";
        public const string SriLankaStandardTime = "Sri Lanka Standard Time";
        public const string NepalStandardTime = "Nepal Standard Time";
        public const string NCentralAsiaStandardTime = "N. Central Asia Standard Time";
        public const string CentralAsiaStandardTime = "Central Asia Standard Time";
        public const string MyanmarStandardTime = "Myanmar Standard Time";
        public const string SEAsiaStandardTime = "SE Asia Standard Time";
        public const string NorthAsiaStandardTime = "North Asia Standard Time";
        public const string ChinaStandardTime = "China Standard Time";
        public const string NorthAsiaEastStandardTime = "North Asia East Standard Time";
        public const string SingaporeStandardTime = "Singapore Standard Time";
        public const string WAustraliaStandardTime = "W. Australia Standard Time";
        public const string TaipeiStandardTime = "Taipei Standard Time";
        public const string TokyoStandardTime = "Tokyo Standard Time";
        public const string KoreaStandardTime = "Korea Standard Time";
        public const string YakutskStandardTime = "Yakutsk Standard Time";
        public const string CenAustraliaStandardTime = "Cen. Australia Standard Time";
        public const string AUSCentralStandardTime = "AUS Central Standard Time";
        public const string EAustraliaStandardTime = "E. Australia Standard Time";
        public const string AUSEasternStandardTime = "AUS Eastern Standard Time";
        public const string WestPacificStandardTime = "West Pacific Standard Time";
        public const string TasmaniaStandardTime = "Tasmania Standard Time";
        public const string VladivostokStandardTime = "Vladivostok Standard Time";
        public const string CentralPacificStandardTime = "Central Pacific Standard Time";
        public const string NewZealandStandardTime = "New Zealand Standard Time";
        public const string FijiStandardTime = "Fiji Standard Time";
        public const string TongaStandardTime = "Tonga Standard Time";
        public const string AzoresStandardTime = "Azores Standard Time";
        public const string CapeVerdeStandardTime = "Cape Verde Standard Time";
        public const string MidAtlanticStandardTime = "Mid-Atlantic Standard Time";
        public const string ESouthAmericaStandardTime = "E. South America Standard Time";
        public const string ArgentinaStandardTime = "Argentina Standard Time";
        public const string SAEasternStandardTime = "SA Eastern Standard Time";
        public const string GreenlandStandardTime = "Greenland Standard Time";
        public const string MontevideoStandardTime = "Montevideo Standard Time";
        public const string NewfoundlandStandardTime = "Newfoundland Standard Time";
        public const string AtlanticStandardTime = "Atlantic Standard Time";
        public const string SAWesternStandardTime = "SA Western Standard Time";
        public const string CentralBrazilianStandardTime = "Central Brazilian Standard Time";
        public const string PacificSAStandardTime = "Pacific SA Standard Time";
        public const string VenezuelaStandardTime = "Venezuela Standard Time";
        public const string SAPacificStandardTime = "SA Pacific Standard Time";
        public const string EasternStandardTime = "Eastern Standard Time";
        public const string USEasternStandardTime = "US Eastern Standard Time";
        public const string CentralAmericaStandardTime = "Central America Standard Time";
        public const string CentralStandardTime = "Central Standard Time";
        public const string CentralStandardTime_Mexico = "Central Standard Time (Mexico)";
        public const string CanadaCentralStandardTime = "Canada Central Standard Time";
        public const string USMountainStandardTime = "US Mountain Standard Time";
        public const string MountainStandardTime_Mexico = "Mountain Standard Time (Mexico)";
        public const string MountainStandardTime = "Mountain Standard Time";
        public const string PacificStandardTime = "Pacific Standard Time";
        public const string PacificStandardTime_Mexico = "Pacific Standard Time (Mexico)";
        public const string AlaskanStandardTime = "Alaskan Standard Time";
        public const string HawaiianStandardTime = "Hawaiian Standard Time";
        public const string SamoaStandardTime = "Samoa Standard Time";
        public const string DatelineStandardTime = "Dateline Standard Time";

    }
}