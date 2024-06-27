using Newtonsoft.Json;

namespace repositorymanagerclient.Models.RepositoryManager
{
    public class Note
    {
        [JsonProperty("_id")]
        public string Id { get; set; } = string.Empty;
        [JsonProperty("note")]
        public string NoteValue { get; set; } = string.Empty;
    }
}
