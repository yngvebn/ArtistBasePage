using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Commands;

namespace Domain.Commands
{
    public class ConnectArtistToLastFm: Command
    {
        public int ArtistId { get; set; }
    }
}
