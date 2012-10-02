using System;
using System.Linq;
using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class CreateReadOnlyToken : IHandleCommand<Commands.CreateReadOnlyToken>
    {
        private readonly IArtistRepository _artistRepository;

        public CreateReadOnlyToken(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(Commands.CreateReadOnlyToken command)
        {
            var artist = _artistRepository.Get(command.ArtistId);
            artist.CreateReadOnlyToken(command.CorrelationId);
        }
    }

    public class CreateReadWriteToken : IHandleCommand<Commands.CreateReadWriteToken>
    {
        private readonly IArtistRepository _artistRepository;

        public CreateReadWriteToken(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(Commands.CreateReadWriteToken command)
        {
            var artist = _artistRepository.Get(command.ArtistId);
            artist.CreateAuthenticatedToken(command.CorrelationId);
        }
    }
}