using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class AddArtistLogonHandleCommand: IHandleCommand<AddArtistLogonCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public AddArtistLogonHandleCommand(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(AddArtistLogonCommand command)
        {
            _artistRepository.Get(command.ArtistId).CreateLogon(command.Username, command.Password);
        }
    }
}