using System.Collections.Generic;
using System.Linq;
using Api.SoundCloud;
using Api.SoundCloud.Interfaces;
using ExternalApi.Models;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace ApiTests
{
    [TestFixture]
    public class SoundCloudApiTests
    {
        private ISoundCloudApi api;

        public SoundCloudApiTests()
        {
            var config = new Mock<ISoundCloudConfig>();
            config.Setup(c => c.BaseUrl).Returns("http://api.soundcloud.com");
            var prms = new List<Parameter>()
                {
                    new Parameter() {Name = "client_id", Type = ParameterType.GetOrPost, Value = "7899c3d96bf9084ec1147e64a5674581"}
                };
            config.Setup(c => c.DefaultParameters).Returns(prms);
            api = new SoundCloudApi(config.Object);
        }

        [Test]
        public void SoundCloundSearch_ShouldReturn_User()
        {
            var result = api.Users.Search("Arne Vatnøy");
            Assert.That(result.Status, Is.EqualTo(ApiResponseStatus.Success));
            Assert.That(result.Data.Count > 0);
            Assert.That(result.Data.Any(c => c.Id == "26193293"));
        }
    }
}