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
        private string _username;
        private string _password;
        //private string _twoFactorOneTimePassword; // Unused, requires addition of /totp to the login url.

        public string SessionId;

        #region Stored data managed by DegiroClient
        public SiteConfig SiteConfig;
        public ClientInfo ClientInfo;
        #endregion

        public DegiroClient()
        {
            // Set up the RestSharp client.
            //RestClient _restClient = new RestClient(BaseTraderUrl);
        }

        /// <summary>
        /// Logs in to the DEGIRO API. Also sets the SessionId variable for further requests.
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            _username = username;
            _password = password;

            var loginPayload = JsonConvert.SerializeObject(new Login()
            {
                Username = _username,
                Password = _password,
                IsRedirectToMobile = false,
                IsPassCodeReset = false
            });

            var req = new RequestHelper<IRestResponse>();
            var response = req.Perform(APIConstants.BaseUrl, "/login/secure/login", Method.POST, body: loginPayload);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
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
                return false;
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
            var req = new RequestHelper<SiteConfig>();
            var response = req.Perform(APIConstants.BaseUrl, "/login/secure/config", Method.GET, true, SessionId);

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
            var req = new RequestHelper<ClientInfo>();
            var response = req.Perform(SiteConfig.PaUrl, $"/client?sessionId={SessionId}", Method.GET, true, SessionId);

            // Update client info.
            ClientInfo = response.Data;
            return response.Data;
        }
    }
}