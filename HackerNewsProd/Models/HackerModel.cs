using Newtonsoft.Json;

namespace HackerNewsProd.Models
{
    public class HackerModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string title { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string url { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string by { get; set; }

    }
}