using Infrastructure.Commands;

namespace Domain.Commands
{
    public class UpdateArtistCommand: Command
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }

}