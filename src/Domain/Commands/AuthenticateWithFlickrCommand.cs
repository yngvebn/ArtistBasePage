using Infrastructure.Commands;

namespace Domain.Commands
{
    public class AuthenticateWithFlickrCommand: Command
    {
        public string Token { get; set; }

        public int ArtistId { get; set; }

        public string Secret { get; set; }
    }
}