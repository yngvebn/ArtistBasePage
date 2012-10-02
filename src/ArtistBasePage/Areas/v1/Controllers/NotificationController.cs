using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtistBasePage.Areas.Admin.ViewModels;
using ArtistBasePage.Infrastructure;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class NotificationController : TokenApiController
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        //
        // GET: /v1/Notification/
        public NotificationController(IMapper mapper, IArtistRepository artistRepository)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
        }

        public IEnumerable<NotificationViewModel> Get()
        {
            return _mapper.Map<IEnumerable<NotificationViewModel>>(_artistRepository.Get(ArtistId).Notifications.Where(c => !c.Read));
        }

    }
}
