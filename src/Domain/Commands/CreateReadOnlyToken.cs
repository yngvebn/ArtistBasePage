using Infrastructure.Commands;

namespace Domain.Commands
{
    public class CreateReadOnlyToken: Command
    {
        public int ArtistId { get; set; } 
    }

    public class CreateReadWriteToken : Command
    {
        public int ArtistId { get; set; }
    }
}