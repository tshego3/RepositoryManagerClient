using Newtonsoft.Json;

namespace repositorymanagerclient.Models.RepositoryManager
{
    public class Nexuse
    {
        [JsonProperty("_id")]
        public string Id { get; set; } = string.Empty;
        [JsonProperty("nexuse")]
        public string NexuseValue { get; set; } = string.Empty;
        [JsonProperty("raw_nexuse")]
        public string RawNexuse { get; set; } = string.Empty;
    }
}
