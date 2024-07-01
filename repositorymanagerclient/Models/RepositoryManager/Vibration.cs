using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace repositorymanagerclient.Models.RepositoryManager
{
    public class Vibration
    {
        [JsonProperty("_id"), Display(Name = "ID")]
        public string Id { get; set; } = string.Empty;
        [JsonProperty("track_name"), Display(Name = "Track Name")]
        public string TrackName { get; set; } = string.Empty;
        [JsonProperty("artist_name"), Display(Name = "Artist Name")]
        public string ArtistName { get; set; } = string.Empty;
        [JsonProperty("album_name"), Display(Name = "Album Name")]
        public string AlbumName { get; set; } = string.Empty;
    }
}
