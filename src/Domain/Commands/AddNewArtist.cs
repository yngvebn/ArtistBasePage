using Domain.Core;

namespace Domain.Commands
{
    public class AddNewArtist: Command
    {
        public string Email { get; set; }    
    }
}