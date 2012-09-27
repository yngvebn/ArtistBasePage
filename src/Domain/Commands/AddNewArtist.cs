using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands
{
    public class AddNewArtist: Command
    {
        public string Email { get; set; }    
    }
}