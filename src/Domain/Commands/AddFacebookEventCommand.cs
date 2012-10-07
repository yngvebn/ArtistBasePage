using Infrastructure.Commands;

namespace Domain.Commands
{
    public class AddFacebookEventCommand: Command
    {
        public int ArtistId { get; set; }

        public string FacebookEventId { get; set; }
    }
}