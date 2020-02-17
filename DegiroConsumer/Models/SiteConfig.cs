using Newtonsoft.Json;

namespace DegiroConsumer.Models
{
    public class SiteConfig
    {
        [JsonProperty("tradingUrl")]
        public string TradingUrl { get; set; }

        [JsonProperty("paUrl")]
        public string PaUrl { get; set; }

        [JsonProperty("reportingUrl")]
        public string ReportingUrl { get; set; }

        [JsonProperty("paymentServiceUrl")]
        public string PaymentServiceUrl { get; set; }

        [JsonProperty("productSearchUrl")]
        public string ProductSearchUrl { get; set; }

        [JsonProperty("dictionaryUrl")]
        public string DictionaryUrl { get; set; }

        [JsonProperty("productTypesUrl")]
        public string ProductTypesUrl { get; set; }

        [JsonProperty("companiesServiceUrl")]
        public string CompaniesServiceUrl { get; set; }

        [JsonProperty("i18nUrl")]
        public string I18NUrl { get; set; }

        [JsonProperty("vwdQuotecastServiceUrl")]
        public string VwdQuotecastServiceUrl { get; set; }

        [JsonProperty("vwdNewsUrl")]
        public string VwdNewsUrl { get; set; }

        [JsonProperty("vwdGossipsUrl")]
        public string VwdGossipsUrl { get; set; }

        [JsonProperty("firstLoginWizardUrl")]
        public string FirstLoginWizardUrl { get; set; }

        [JsonProperty("taskManagerUrl")]
        public string TaskManagerUrl { get; set; }

        [JsonProperty("landingPath")]
        public string LandingPath { get; set; }

        [JsonProperty("betaLandingPath")]
        public string BetaLandingPath { get; set; }

        [JsonProperty("mobileLandingPath")]
        public string MobileLandingPath { get; set; }

        [JsonProperty("loginUrl")]
        public string LoginUrl { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("clientId")]
        public int ClientId { get; set; }
    }
}