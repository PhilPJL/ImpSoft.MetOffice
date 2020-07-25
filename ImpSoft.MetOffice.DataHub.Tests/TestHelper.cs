using System;
using System.Net.Http;

namespace ImpSoft.MetOffice.DataHub.Tests
{
    internal static class TestHelper
    {
        public static IDataHubClient CreateClient<TResponse>(Uri expectedUri, TResponse response) where TResponse : class
        {
            // Do I care about disposing these?
            var httpClient = new HttpClient(new FakeHttpMessageHandler<TResponse>(expectedUri, response));

            return new DataHubClient(httpClient);
        }

        public static IDataHubClient CreateClient<TResponse>(string expectedUri, TResponse response) where TResponse : class
        {
            // Do I care about disposing these?
            var httpClient = new HttpClient(new FakeHttpMessageHandler<TResponse>(new Uri(expectedUri), response));

            return new DataHubClient(httpClient);
        }

        public static IDataHubClient CreateClient(string expectedUri, string response)
        {
            // Do I care about disposing these?
            var httpClient = new HttpClient(new FakeHttpMessageHandler<string>(new Uri(expectedUri), response));

            return new DataHubClient(httpClient);
        }
    }

}
