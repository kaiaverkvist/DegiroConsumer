using Newtonsoft.Json;

namespace DegiroConsumer.Models.Account
{
    public class AccountAddress
    {
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("streetAddressNumber")]
        public string StreetAddressNumber { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}