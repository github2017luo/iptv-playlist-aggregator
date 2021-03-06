using NUnit.Framework;

using Moq;

using IptvPlaylistAggregator.Service;
using IptvPlaylistAggregator.Service.Models;

namespace IptvPlaylistAggregator.UnitTests.Service.Models
{
    public sealed class ChannelMatcherTests
    {
        Mock<ICacheManager> cacheMock;
        
        IChannelMatcher channelMatcher;

        [SetUp]
        public void SetUp()
        {
            cacheMock = new Mock<ICacheManager>();

            channelMatcher = new ChannelMatcher(cacheMock.Object);
        }

        [Test]
        public void DoesMatch_CompareWithSameValue_ReturnsTrue()
        {
            string definedName = "Digi Sport 2";
            string providerName = "RO: Digi Sport 2";
            string alias = "RO: Digi Sport 2";

            ChannelName channelName = new ChannelName(definedName, alias);

            Assert.IsTrue(channelMatcher.DoesMatch(channelName, providerName));
        }

        [Test]
        public void DoesMatch_CompareWithSameValueDifferentCasing_ReturnsTrue()
        {
            string definedName = "Digi Sport 2";
            string providerName = "RO: Digi Sport 2";
            string alias = "RO: DIGI Sport 2";

            ChannelName channelName = new ChannelName(definedName, alias);

            Assert.IsTrue(channelMatcher.DoesMatch(channelName, providerName));
        }

        [Test]
        public void DoesMatch_CompareWithSameValueWithDiacritics_ReturnsTrue()
        {
            string definedName = "TVR Timișoara";
            string providerName = "RO: TVR Timisoara";
            string alias = "RO: TVR Timișoara";

            ChannelName channelName = new ChannelName(definedName, alias);

            Assert.IsTrue(channelMatcher.DoesMatch(channelName, providerName));
        }

        [Test]
        public void DoesMatch_CompareWithSameValueWithBlacklistedSubstrings_ReturnsTrue()
        {
            string definedName = "Digi Sport 2";
            string providerName = "RO: Digi Sport 2 [Multi-Audio]";
            string alias = "RO: Digi Sport 2";

            ChannelName channelName = new ChannelName(definedName, alias);

            Assert.IsTrue(channelMatcher.DoesMatch(channelName, providerName));
        }

        [Test]
        public void DoesMatch_CompareWithDifferentValue_ReturnsFalse()
        {
            string definedName = "Digi Sport 2";
            string providerName = "RO: Digi Sport 2";
            string alias = "RO: Telekom Sport 2";

            ChannelName channelName = new ChannelName(definedName, alias);

            Assert.IsFalse(channelMatcher.DoesMatch(channelName, providerName));
        }
    }
}
