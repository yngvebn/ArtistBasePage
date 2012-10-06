using System;
using Infrastructure.Commands;

namespace Domain.Commands
{
    public class AddNewEventCommand: Command
    {
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
    }
}