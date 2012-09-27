using System;
using System.Linq;
using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class CreateReadOnlyTokenHandler: ICommandHandler<CreateReadOnlyToken>
    {
        private readonly IArtistRepository _artistRepository;

        public CreateReadOnlyTokenHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(CreateReadOnlyToken command)
        {
            var artist = _artistRepository.Get(command.ArtistId);
            var token = artist.ApiSessions.SingleOrDefault(c => c.Expires > DateTime.Now);
            if(token == null) artist.GetReadonlyToken();
        }
    }
}