using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class ConnectArtistToLastFmCommandHandler: IHandleCommand<ConnectArtistToLastFm>
    {
        private readonly IArtistRepository _artistRepository;

        public ConnectArtistToLastFmCommandHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(ConnectArtistToLastFm command)
        {
            _artistRepository.Get(command.ArtistId).ConnectToLastFm();
        }
    }
}