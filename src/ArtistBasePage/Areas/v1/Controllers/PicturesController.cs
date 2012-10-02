using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtistBasePage.Infrastructure;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class PicturesController : TokenApiController
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly ILastFmExternalRepository _lastFmRepository;
        //
        // GET: /v1/Pictures/

        public PicturesController(IMapper mapper, IArtistRepository artistRepository, ILastFmExternalRepository lastFmRepository)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
            _lastFmRepository = lastFmRepository;
        }

        public IEnumerable<PictureViewModel> Get()
        {
            var artist = _artistRepository.Get(ArtistId);
            if (artist.LastFmInfo.UsePictures)
                foreach (var image in _lastFmRepository.Get(ArtistId))
                    yield return _mapper.Map<PictureViewModel>(image);
        }

    }

    public class PictureViewModel
    {
        public ImageSize Size { get; set; }
        public string Url { get; set; }
    }

    public enum ImageSize
    {
        /// <summary>
        /// Small image size
        /// </summary>
        Small,

        /// <summary>
        /// Medium image size
        /// </summary>
        Medium,

        /// <summary>
        /// Large image size
        /// </summary>
        Large,

        /// <summary>
        /// Extra large image size
        /// </summary>
        ExtraLarge,

        /// <summary>
        /// Mega image size
        /// </summary>
        Mega
    }
}
