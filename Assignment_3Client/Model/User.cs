using System.Text.Json.Serialization;

namespace Assignment_3Client.Model
{
    public class User
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("userId")]
        
        public int UserId { get; set; }
        [JsonPropertyName("securityLevel")]
        public int SecurityLevel { get; set; }
    }
}