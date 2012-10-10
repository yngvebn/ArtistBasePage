using System.Web.Http;
using ArtistBasePage.Infrastructure;
using Infrastructure.Commands;

namespace ArtistBasePage.Areas.v1.Core
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
    }
}