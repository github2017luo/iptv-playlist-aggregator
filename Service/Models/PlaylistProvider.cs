namespace IptvPlaylistFetcher.Service.Models
{
    public class PlaylistProvider
    {
        public string Id { get; set; }

        public bool IsEnabled { get; set; }

        public string Name { get; set; }

        public string UrlFormat { get; set; }
    }
}
