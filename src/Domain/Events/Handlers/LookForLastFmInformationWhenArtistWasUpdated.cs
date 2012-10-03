using System.Threading.Tasks;
using Domain.Commands;
using DotLastFm.Api;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Events.Handlers
{
    public class LookForLastFmInformationWhenArtistWasUpdated: IHandleDomainEvent<ArtistWasUpdated>
    {
        private readonly ICommandExecutor _commandExecutor;

        public LookForLastFmInformationWhenArtistWasUpdated(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        public void Handle(ArtistWasUpdated domainEvent)
        {
            System.Threading.Thread.Sleep(5000);
            
            Task<CommandResult>.Factory.StartNew(() => _commandExecutor.ExecuteCommand(new LookForLastFmInformation()
                                                     {
                                                         Artist = domainEvent.Artist
                                                     }));
            
        }
    }
}