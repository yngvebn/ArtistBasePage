using Infrastructure.Commands;

namespace Domain.Commands
{
    public class SetFlickrRequestToken: Command
    {
        public int ArtistId { get; set; }

        public string Token { get; set; }

        public string Secret { get; set; }
    }
}