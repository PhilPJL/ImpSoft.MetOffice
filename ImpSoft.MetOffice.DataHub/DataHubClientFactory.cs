namespace ImpSoft.MetOffice.DataHub
{
    public static class DataHubClientFactory
    {
        /// <summary>
        /// Create an instance of the data hub client.
        /// </summary>
        /// <param name="clientId">Your application's client Id.</param>
        /// <param name="clientSecret">Your application's client secret.</param>
        /// <returns></returns>
        public static IDataHubClient Create(string clientId, string clientSecret)
        {
            return new DataHubClient(clientId, clientSecret);
        }
    }
}
