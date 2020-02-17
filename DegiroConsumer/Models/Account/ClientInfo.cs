using Newtonsoft.Json;

namespace DegiroConsumer.Models.Account
{
    public class ClientInfo
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

    }

    public partial class Data
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("intAccount")]
        public long IntAccount { get; set; }

        [JsonProperty("clientRole")]
        public string ClientRole { get; set; }

        [JsonProperty("effectiveClientRole")]
        public string EffectiveClientRole { get; set; }

        [JsonProperty("contractType")]
        public string ContractType { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstContact")]
        public FirstContact FirstContact { get; set; }

        [JsonProperty("address")]
        public AccountAddress Address { get; set; }

        [JsonProperty("cellphoneNumber")]
        public string CellphoneNumber { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("culture")]
        public string Culture { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }

        [JsonProperty("memberCode")]
        public string MemberCode { get; set; }

        [JsonProperty("isWithdrawalAvailable")]
        public bool IsWithdrawalAvailable { get; set; }

        [JsonProperty("isAllocationAvailable")]
        public bool IsAllocationAvailable { get; set; }

        [JsonProperty("isIskClient")]
        public bool IsIskClient { get; set; }

        [JsonProperty("isCollectivePortfolio")]
        public bool IsCollectivePortfolio { get; set; }

        [JsonProperty("isAmClientActive")]
        public bool IsAmClientActive { get; set; }

        [JsonProperty("canUpgrade")]
        public bool CanUpgrade { get; set; }
    }
}