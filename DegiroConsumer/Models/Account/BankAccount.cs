using Newtonsoft.Json;

namespace DegiroConsumer.Models.Account
{
    public class BankAccount
    {
        [JsonProperty("bankAccountId")]
        public long BankAccountId { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}