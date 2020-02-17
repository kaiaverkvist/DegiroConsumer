using Newtonsoft.Json;

namespace DegiroConsumer.Models
{
    /// <summary>
    /// Represents the JSON used for the login POST.
    /// </summary>
    public class Login
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("isRedirectToMobile")]
        public bool IsRedirectToMobile { get; set; }

        [JsonProperty("isPassCodeReset")]
        public bool IsPassCodeReset { get; set; }
    }
}