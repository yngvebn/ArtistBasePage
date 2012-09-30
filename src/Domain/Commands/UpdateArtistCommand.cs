using Infrastructure.Commands;

namespace Domain.Commands
{
    public class UpdateArtistCommand: Command
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }

    public class AddSocialNetworkCommand: Command
    {
        public int ArtistId { get; set; }

        public SocialNetworkType SocialNetworkType { get; set; }
        public string Url { get; set; }
    }
}