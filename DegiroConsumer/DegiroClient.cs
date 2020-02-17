using System;
using System.Net;
using DegiroConsumer.Constants;
using DegiroConsumer.Models;
using DegiroConsumer.Models.Account;
using DegiroConsumer.RequestPayloads;
using Newtonsoft.Json;
using RestSharp;

namespace DegiroConsumer
{
    public class DegiroClient
    {
        private readonly string _username;
        private readonly string _password;
        //private string _twoFactorOneTimePassword; // Unused, requires addition of /totp to the login url.

        public string SessionId;

        #region Stored data managed by DegiroClient
        public SiteConfig SiteConfig;
        public ClientInfo ClientInfo;
        #endregion

        public DegiroClient(string username, string password)
        {
            // Set up the RestSharp client.
            //RestClient _restClient = new RestClient(BaseTraderUrl);

            _username = username;
            _password = password;
        }

        /// <summary>
        /// Logs in to the DEGIRO API. Also sets the SessionId variable for further requests.
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <returns></returns>
        public bool Login()
        {   
            RestClient restClient = new RestClient(APIConstants.BaseUrl);
            var request = new RestRequest("/login/secure/login", Method.POST, DataFormat.Json)
                .AddHeader("content-type", "application/json")
                .AddBody(JsonConvert.SerializeObject(new Login()
                {
                    Username = _username,
                    Password = _password,
                    IsRedirectToMobile = false,
                    IsPassCodeReset = false
                }));
                
            IRestResponse response = restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Unable to access API endpoint for user login.");
            }

            #region Update session id
            foreach (var cookie in response.Cookies)
            {
                if (cookie.Name == "JSESSIONID")
                {
                    SessionId = cookie.Value;
                }
            }

            if (SessionId == null)
            {
                throw new Exception("Unable to retrieve session from API.");
            }
            #endregion


            // This acts as a discovery of available services. See the SiteConfig class for information.
            UpdateConfig();

            return true;
        }

        /// <summary>
        /// Updates the config by fetching the relevant URLs.
        /// This is also a discovery service for every other URL.
        /// (Will also update the SiteConfig instance declared by DegiroClient).
        /// </summary>
        /// <returns></returns>
        public SiteConfig UpdateConfig()
        {
            RestClient restClient = new RestClient(APIConstants.BaseUrl);
            var request = new RestRequest("/login/secure/config", Method.GET, DataFormat.Json)
                .AddHeader("content-type", "application/json")
                .AddCookie(APIConstants.SessionCookieName, SessionId);

            IRestResponse<SiteConfig> response = restClient.Execute<SiteConfig>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Unable to access API endpoint for service discovery.");
            }

            SiteConfig = response.Data;

            // Fetch client info which will also be stored.
            GetClientInfo();

            return response.Data;
        }

        /// <summary>
        /// GetClientInfo returns data about the user. See the ClientInfo class.
        /// </summary>
        /// <returns></returns>
        public ClientInfo GetClientInfo()
        {
            RestClient restClient = new RestClient(SiteConfig.PaUrl);
            var request = new RestRequest($"/client?sessionId={SessionId}", Method.GET, DataFormat.Json)
                .AddHeader("content-type", "application/json")
                .AddCookie(APIConstants.SessionCookieName, SessionId);

            IRestResponse<ClientInfo> response = restClient.Execute<ClientInfo>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Unable to access API endpoint for client info retrieval.");
            }

            // Update client info.
            ClientInfo = response.Data;
            return response.Data;
        }
    }
}