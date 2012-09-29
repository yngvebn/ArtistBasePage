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
            var token = artist.ApiSessions.Where(c => !c.Write).SingleOrDefault(c => c.Expires > DateTime.Now);
            if (token == null) artist.GetReadonlyToken();
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
            var token = artist.ApiSessions.Where(c => c.Read && c.Write).SingleOrDefault(c => c.Expires > DateTime.Now);
            if (token == null) artist.GetReadWriteToken();
        }
    }
}