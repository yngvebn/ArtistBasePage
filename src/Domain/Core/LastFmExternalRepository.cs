using System.Collections.Generic;
using DotLastFm.Api;
using DotLastFm.Models;

namespace Domain.Core
{
    public class LastFmExternalRepository : ILastFmExternalRepository
    {
        private readonly ILastFmApi _lastFmApi;
        private readonly IArtistRepository _artistRepository;

        public LastFmExternalRepository(ILastFmApi lastFmApi, IArtistRepository artistRepository)
        {
            _lastFmApi = lastFmApi;
            _artistRepository = artistRepository;
        }

        public IEnumerable<Image> Get(int artistId)
        {
            var lastFmName = _artistRepository.Get(artistId).LastFmInfo.Name;
            var apiResponse = _lastFmApi.Artist.GetInfo(lastFmName);
            return apiResponse.Images;
        }

        public IEnumerable<DotLastFm.Models.Event> GetEvents(int artistId)
        {
            var lastFmName = _artistRepository.Get(artistId).LastFmInfo.Name;
            return _lastFmApi.Artist.GetEvents(lastFmName);
        }
    }
}