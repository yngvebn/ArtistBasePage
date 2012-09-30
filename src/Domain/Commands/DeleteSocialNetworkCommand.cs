using Infrastructure.Commands;

namespace Domain.Commands
{
    public class DeleteSocialNetworkCommand: Command
    {
        public SocialNetworkType Type { get; set; }

        public int ArtistId { get; set; }
    }
}