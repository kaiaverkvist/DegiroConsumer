using System;
using System.Net;
using DegiroConsumer.Constants;
using DegiroConsumer.Models;
using RestSharp;

namespace DegiroConsumer
{
    public class RequestHelper<T>
    {
        public IRestResponse<T> Perform(string baseUrl, string endpoint, Method method, bool authenticated = false, string sessionId = "", object body = null)
        {
            RestClient restClient = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, method, DataFormat.Json)
                .AddHeader("content-type", "application/json");

            if (body != null)
            {
                request.AddJsonBody(body);
            }

            if (authenticated)
            {
                request.AddCookie(APIConstants.SessionCookieName, sessionId);
            }

            IRestResponse<T> response = restClient.Execute<T>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Unable to access endpoint: {endpoint}. StatusCode: {response.StatusCode}");
            }

            return response;
        }
    }
}