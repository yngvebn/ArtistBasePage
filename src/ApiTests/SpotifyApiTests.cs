using Api.Spotify;
using Api.Spotify.Interfaces;
using ExternalApi.Models;
using Moq;
using NUnit.Framework;

namespace ApiTests
{
    [TestFixture]
    public class SpotifyApiTests
    {
        private ISpotifyApi api;

        public SpotifyApiTests()
        {
            var config = new Mock<ISpotifyApiConfig>();
            config.Setup(c => c.BaseUrl).Returns("http://ws.spotify.com/search/1/");
            api = new SpotifyApi(config.Object);
        }

        [Test]
        public void SpotifySearch_ShouldReturn_User()
        {
            var result = api.Artist.Search("Arne Vatnøy");
            Assert.That(result.Status, Is.EqualTo(ApiResponseStatus.Success));
            Assert.That(result.Data.Artists.Count > 0);
        }
    }
}