using System;
using System.Linq;
using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class CreateReadOnlyTokenHandler : ICommandHandler<CreateReadOnlyToken>
    {
        private readonly IArtistRepository _artistRepository;

        public CreateReadOnlyTokenHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(CreateReadOnlyToken command)
        {
            var artist = _artistRepository.Get(command.ArtistId);
            artist.CreateReadOnlyToken(command.CorrelationId);
        }
    }

    public class CreateReadWriteTokenHandler : ICommandHandler<CreateReadWriteToken>
    {
        private readonly IArtistRepository _artistRepository;

        public CreateReadWriteTokenHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(CreateReadWriteToken command)
        {
            var artist = _artistRepository.Get(command.ArtistId);
            artist.CreateAuthenticatedToken(command.CorrelationId);
        }
    }
}