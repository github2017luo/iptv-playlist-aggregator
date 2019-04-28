using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using IptvPlaylistFetcher.Core.Configuration;
using IptvPlaylistFetcher.DataAccess.DataObjects;

namespace IptvPlaylistFetcher.DataAccess.Repositories
{
    public sealed class PlaylistProviderRepository : IPlaylistProviderRepository
    {
        readonly ApplicationSettings settings;

        public PlaylistProviderRepository(ApplicationSettings settings)
        {
            this.settings = settings;
        }

        public IEnumerable<PlaylistProviderEntity> GetAll()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PlaylistProviderEntity>));
            IEnumerable<PlaylistProviderEntity> entities;

            using (TextReader reader = new StreamReader(settings.PlaylistProviderStorePath))
            {
                entities = (IEnumerable<PlaylistProviderEntity>)serializer.Deserialize(reader);
            }

            return entities;
        }
    }
}
