using Domain.Core;
using Domain.Events;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Commands.Handlers
{
    public class UpdateArtistHandleCommand: IHandleCommand<UpdateArtistCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public UpdateArtistHandleCommand(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(UpdateArtistCommand command)
        {
            var artist = _artistRepository.Get(command.ArtistId);
            artist.Update(command.Artist);
            DomainEvents.Raise(new ArtistWasUpdated()
                                   {
                                       Artist = artist
                                   });
        }
    }
}