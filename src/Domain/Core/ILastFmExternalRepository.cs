using System.Collections.Generic;
using DotLastFm.Models;

namespace Domain.Core
{
    public interface ILastFmExternalRepository
    {
        IEnumerable<Image> Get(int artistId);
        IEnumerable<DotLastFm.Models.Event> GetEvents(int artistId);
    }
}