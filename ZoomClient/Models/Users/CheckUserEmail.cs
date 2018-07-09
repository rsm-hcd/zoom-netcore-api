using Newtonsoft.Json;

namespace AndcultureCode.ZoomClient.Models.Users
{
    public class CheckUserEmail
    {
        [JsonProperty("existed_email")]
        public bool EmailExists { get; set; }
    }
}
