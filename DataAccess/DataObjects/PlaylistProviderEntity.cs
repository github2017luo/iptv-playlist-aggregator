using NuciDAL.DataObjects;

namespace IptvPlaylistAggregator.DataAccess.DataObjects
{
    public class PlaylistProviderEntity : EntityBase
    {
        public bool IsEnabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string UrlFormat { get; set; }

        public string ChannelNameOverride { get; set; }
    }
}
