using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class AddArtistLogonCommandHandler: ICommandHandler<AddArtistLogonCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public AddArtistLogonCommandHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(AddArtistLogonCommand command)
        {
            _artistRepository.Get(command.ArtistId).CreateLogon(command.Username, command.Password);
        }
    }
}