using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.iTunes;
using ExternalApi.Models;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace ApiTests
{
    [TestFixture]
    public class TunesApiTests
    {
        private IITunesApi api;
        public TunesApiTests()
        {
            List<Parameter> Params = new List<Parameter>()
                                         {
                                             new Parameter(){ Name = "accept", Type = ParameterType.GetOrPost, Value = "application/json"}
                                         };
            var config = new Mock<ITunesConfig>();
            config.Setup(c => c.BaseUrl).Returns("http://itunes.apple.com/");
            config.Setup(c => c.DefaultParameters).Returns(Params);
            api = new ITunesApi(config.Object);
        }

        [Test]
        public void ITunesSearch_ShouldReturn_Items()
        {
            var result = api.Search.Query("Madonna");
            Assert.That(result.Status, Is.EqualTo(ApiResponseStatus.Success));
            //Assert.That(result.Data.results.Count > 0);
        }
    }
}
