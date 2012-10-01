using Infrastructure.Commands;

namespace Domain.Commands
{
    public class AddArtistLogonCommand: Command
    {
        public int ArtistId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}