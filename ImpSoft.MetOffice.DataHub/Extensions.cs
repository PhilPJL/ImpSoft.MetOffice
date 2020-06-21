using System.Collections.Generic;

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

            throw new ParameterDetailsKeyException($"Parameter details not found for key='{key}'.");
        }
    }
}
