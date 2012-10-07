using Infrastructure.Commands;

namespace Domain.Commands
{
    public class DeleteFacebookEventCommand: Command
    {
        public int ArtistId { get; set; }

        public string FacebookEventId { get; set; }
    }
}