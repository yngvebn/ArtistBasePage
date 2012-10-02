using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class UpdateLastFmInfoCommandHandler: IHandleCommand<UpdateLastFmInfoCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public UpdateLastFmInfoCommandHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(UpdateLastFmInfoCommand command)
        {
            _artistRepository.Get(command.ArtistId).UpdateLastFmSettings(command.UseBio, command.UseEvents, command.UsePictures);
        }
    }
}