using System.Collections.Generic;
using DotLastFm.Models;
using Facebook;

namespace Domain.Core
{
    public interface ILastFmExternalRepository
    {
        IEnumerable<Image> Get(int artistId);
        IEnumerable<DotLastFm.Models.Event> GetEvents(int artistId);
    }
}