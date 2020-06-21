namespace ImpSoft.MetOffice.DataHub
{
    public static class MetOfficeDataHubApiFactory
    {
        public static IMetOfficeDataHubApi Create(string clientId, string clientSecret)
        {
            return new MetOfficeDataHubApi(clientId, clientSecret);
        }
    }
}
