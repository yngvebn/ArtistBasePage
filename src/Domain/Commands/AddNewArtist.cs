using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands
{
    public class AddNewArtist: Command
    {
        public string Creator { get; set; }
        public string Name { get; set; }    
    }
}