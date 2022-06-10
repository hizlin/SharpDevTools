using System.Text.Json.Serialization;

namespace VsTidy.Core.Models
{
    public class Signer : JsonBase
    {
        [JsonPropertyName("$id")]
        public string id { get; set; }

        public string subjectName { get; set; }
    }

}
