using Newtonsoft.Json;

namespace repositorymanagerclient.Models.RepositoryManager
{
    public class Vibration
    {
        [JsonProperty("_id")]
        public string Id { get; set; } = string.Empty;
        [JsonProperty("track_name")]
        public string TrackName { get; set; } = string.Empty;
        [JsonProperty("artist_name")]
        public string ArtistName { get; set; } = string.Empty;
        [JsonProperty("album_name")]
        public string AlbumName { get; set; } = string.Empty;
    }
}
