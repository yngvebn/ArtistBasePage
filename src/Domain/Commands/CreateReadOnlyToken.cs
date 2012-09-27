using Infrastructure.Commands;

namespace Domain.Commands
{
    public class CreateReadOnlyToken: Command
    {
        public int ArtistId { get; set; } 
    }
}