using System;
using System.Collections.Generic;
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
}