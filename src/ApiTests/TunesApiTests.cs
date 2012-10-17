using System;
using System.Text;
using System.Threading.Tasks;
using Api.iTunes;
using Api.iTunes.Interfaces;
using ExternalApi.Models;
using Moq;
using NUnit.Framework;

namespace ApiTests
{
    [TestFixture]
    public class TunesApiTests
    {
        private IITunesApi api;
        public TunesApiTests()
        {
            var config = new Mock<ITunesConfig>();
            config.Setup(c => c.BaseUrl).Returns("http://itunes.apple.com/");
            api = new MainApi(config.Object);
        }

        [Test]
        public void ITunesSearch_ShouldReturn_Items()
        {
            var result = api.Search.Query("Madonna");
            Assert.That(result.Status, Is.EqualTo(ApiResponseStatus.Success));
            Assert.That(result.Data.Results.Count > 0);
        }
    }
}
