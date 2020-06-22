namespace ImpSoft.MetOffice.DataHub
{
    public static class MetOfficeDataHubApiFactory
    {
        /// <summary>
        /// Create an instance of the data hub api client.
        /// </summary>
        /// <param name="clientId">Your application's client Id./param>
        /// <param name="clientSecret">Your application's client secret.</param>
        /// <returns></returns>
        public static IMetOfficeDataHubApi Create(string clientId, string clientSecret)
        {
            return new MetOfficeDataHubApi(clientId, clientSecret);
        }
    }
}
