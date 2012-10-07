using Facebook.Api;

namespace Domain.Core
{
    public interface IFacebookExternalRepository
    {
        Facebook.Models.Event GetEvent(string id);
    }

    public class FacebookExternalRepository : IFacebookExternalRepository
    {
        private readonly IFacebookApi _api;

        public FacebookExternalRepository(IFacebookApi api)
        {
            _api = api;
        }

        public Facebook.Models.Event GetEvent(string id)
        {
            var ev = _api.Event.GetEvent(id);
            if (ev.Venue != null)
                ev.Venue = _api.Event.GetLocation(ev.Venue.Id);

            return ev;
        }
    }
}