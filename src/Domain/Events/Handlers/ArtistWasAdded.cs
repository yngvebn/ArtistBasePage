using System.Threading.Tasks;
using Domain.Commands;
using Domain.Core;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Events.Handlers
{
    public class ArtistWasAdded: IHandleDomainEvent<Events.ArtistWasAdded>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IArtistRepository _artistRepository;

        public ArtistWasAdded(ICommandExecutor commandExecutor, IArtistRepository artistRepository)
        {
            _commandExecutor = commandExecutor;
            _artistRepository = artistRepository;
        }

        public void Handle(Events.ArtistWasAdded domainEvent)
        {
            Task<CommandResult>.Factory.StartNew(() => _commandExecutor.ExecuteCommand(new FindArtistInformationOnExternalServices()
            {
                Artist = domainEvent.Artist
            }));
        }
    }
}