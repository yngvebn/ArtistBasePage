using System.Collections.Generic;
using ArtistBasePage.Areas.v1.ViewModels;

namespace ArtistBasePage.Areas.v1.Orchestrators
{
    public interface IEventOrchestrator
    {
        IEnumerable<EventViewModel> Get(int artistId);
        void Delete(int artistId, string id, int source);
        void Create(int artistId, CreateEventViewModel eventViewModel);
    }
}