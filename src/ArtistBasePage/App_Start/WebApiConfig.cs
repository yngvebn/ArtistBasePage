using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ArtistBasePage
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            RegisterCustomFormatters(config);
        }

        public static void RegisterCustomFormatters(HttpConfiguration configuration)
        {
            var formatter = configuration.Formatters.OfType<JsonMediaTypeFormatter>().First();

            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            var converter = new IsoDateTimeConverter
            {
                DateTimeStyles = DateTimeStyles.RoundtripKind,
                DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'sszzz"
            };

            settings.Converters.Add(converter);

            formatter.SerializerSettings = settings;
        }
    }
}
