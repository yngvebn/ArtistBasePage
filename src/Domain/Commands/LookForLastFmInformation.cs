using Infrastructure.Commands;

namespace Domain.Commands
{
    public class LookForLastFmInformation: Command
    {
        public Artist Artist { get; set; }
    }
}