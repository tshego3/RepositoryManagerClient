using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace repositorymanagerclient.Models.RepositoryManager
{
    public class Nexuse
    {
        [JsonProperty("_id"), Display(Name = "ID")]
        public string Id { get; set; } = string.Empty;
        [JsonProperty("nexuse"), Display(Name = "Name")]
        public string NexuseValue { get; set; } = string.Empty;
        [JsonProperty("raw_nexuse"), Display(Name = "URL")]
        public string RawNexuse { get; set; } = string.Empty;
    }
}
