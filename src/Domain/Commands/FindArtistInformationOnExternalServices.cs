using Infrastructure.Commands;

namespace Domain.Commands
{
    public class FindArtistInformationOnExternalServices: Command
    {
        public Artist Artist { get; set; }
    }
}