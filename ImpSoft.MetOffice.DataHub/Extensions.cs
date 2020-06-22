using ImpSoft.MetOffice.DataHub.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ImpSoft.MetOffice.DataHub
{
    public static class Extensions
    {
        public static ParameterDetails GetDetails(this Dictionary<string, ParameterDetails> details, string key)
        {
            if (details.ContainsKey(key))
            {
                return details[key];
            }

            throw new ParameterDetailsKeyException(string.Format(CultureInfo.CurrentCulture, Resources.ParameterKeyError, key));
        }

        public static string StripAsyncSuffix(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return name;
            }

            if (name.EndsWith("Async", StringComparison.OrdinalIgnoreCase))
            {
                return name.Substring(0, name.Length - 5);
            }

            return name;
        }
    }
}
