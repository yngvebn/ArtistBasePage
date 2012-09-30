using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Domain.Core;
using Infrastructure.Commands;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class TokenApiController: ApiController
    {

        protected CommandResult Execute(Command command)
        {
            return MvcApplication.CommandExecutor.ExecuteCommand(command);
        }
        private readonly IArtistRepository _artistRepository;
        public int ArtistId { get; set; }
        public TokenApiController()
        {
            _artistRepository = DependencyResolver.Current.GetService<IArtistRepository>();
        }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            IEnumerable<string> values = new List<string>();
            var token = controllerContext.Request.Headers.TryGetValues("t", out values);
            if (values == null)
                throw new HttpException(401, "Token is required");

            var artist = _artistRepository.FindByToken(values.FirstOrDefault());
            ArtistId = artist.Id; 
            base.Initialize(controllerContext);
        }
    }
}