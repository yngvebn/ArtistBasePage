using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ArtistBasePage.Infrastructure;
using Domain.Core;
using Infrastructure.Commands;

namespace ArtistBasePage.Areas.v1.Controllers
{
    [TokenAuthentication]
    public class TokenApiController: ApiController
    {
        protected CommandResult Execute(Command command)
        {
            return MvcApplication.CommandExecutor.ExecuteCommand(command);
            
        }
        private readonly IArtistRepository _artistRepository;
        private readonly ITokenRepository _tokenRepository;
        public int ArtistId { get; set; }
        public bool CanWrite { get; set; }
        public TokenApiController()
        {
            _artistRepository = DependencyResolver.Current.GetService<IArtistRepository>();
            _tokenRepository = DependencyResolver.Current.GetService<ITokenRepository>();
        }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            IEnumerable<string> values = new List<string>();
            var token = controllerContext.Request.Headers.GetValues("t").SingleOrDefault();

            if (token == null)
                throw new HttpException(401, "Token is required");
            
            if(!_tokenRepository.IsValid(token))
                throw new HttpException(401, "Token has expired");

            var artist = _artistRepository.FindByToken(token);
            ArtistId = artist.Id;
            CanWrite = artist.CanWrite(token);
            base.Initialize(controllerContext);
        }
    }
}