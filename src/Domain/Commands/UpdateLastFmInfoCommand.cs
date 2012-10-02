using Infrastructure.Commands;

namespace Domain.Commands
{
    public class UpdateLastFmInfoCommand:Command
    {
        public int ArtistId { get; set; }

        public bool UseBio { get; set; }

        public bool UseEvents { get; set; }

        public bool UsePictures { get; set; }
    }
}