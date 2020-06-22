using ImpSoft.MetOffice.DataHub.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ImpSoft.MetOffice.DataHub
{
    public static class Extensions
    {
        /// <summary>
        /// Retrieves a ParameterDetails instance from the dictionary given the key.
        /// </summary>
        /// <param name="details">A dictionary of parameter key to ParameterDetails</param>
        /// <param name="key">The parameter key</param>
        /// <returns>ParameterDetails</returns>
        public static ParameterDetails GetDetails(this Dictionary<string, ParameterDetails> details, string key)
        {
            if (details.ContainsKey(key))
            {
                return details[key];
            }

            throw new ParameterDetailsKeyException(string.Format(CultureInfo.CurrentCulture, Resources.ParameterKeyError, key));
        }

        internal static string StripAsyncSuffix(this string name)
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
