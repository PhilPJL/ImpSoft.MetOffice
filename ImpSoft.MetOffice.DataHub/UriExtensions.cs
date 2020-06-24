using System;
using System.Globalization;

namespace ImpSoft.MetOffice.DataHub
{
    internal static class UriExtensions
    {
        public static Uri AddQueryParam(this Uri uri, string name, bool? value)
        {
            return value == null ? uri : uri.AddQueryParam(name, value.Value ? "true" : "false");
        }

        public static Uri AddQueryParam(this Uri uri, string name, int value)
        {
            return uri.AddQueryParam(name, value.ToString(CultureInfo.InvariantCulture));
        }

        public static Uri AddQueryParam(this Uri uri, string name, decimal value)
        {
            return uri.AddQueryParam(name, value.ToString(CultureInfo.InvariantCulture));
        }

        public static Uri AddQueryParam(this Uri uri, string name, string value)
        {
            var baseUri = new UriBuilder(uri);

            var param = $"{name}={value}";

            baseUri.Query = baseUri.Query.Length > 1 ? baseUri.Query.Substring(1) + "&" + param : param;

            return baseUri.Uri;
        }
    }
}
