using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class UpdateArtistCommandHandler: ICommandHandler<UpdateArtistCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public UpdateArtistCommandHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(UpdateArtistCommand command)
        {
            _artistRepository.Get(command.ArtistId).Update(command.Artist);
        }
    }
}