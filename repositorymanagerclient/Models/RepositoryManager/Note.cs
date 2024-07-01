using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace repositorymanagerclient.Models.RepositoryManager
{
    public class Note
    {
        [JsonProperty("_id"), Display(Name = "ID")]
        public string Id { get; set; } = string.Empty;
        [JsonProperty("note"), Display(Name = "Note")]
        public string NoteValue { get; set; } = string.Empty;
    }
}
