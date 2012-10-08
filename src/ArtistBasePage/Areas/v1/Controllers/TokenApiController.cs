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
        public int ArtistId { get; set; }
        public bool CanWrite { get; set; }
        public TokenApiController()
        {
        }

    }
}