using Api.SoundCloud.Interfaces;

namespace Api.SoundCloud
{
    public class SoundCloudApi: ExternalApi.Rest.ExternalApi, ISoundCloudApi
    {
        public SoundCloudApi(ISoundCloudConfig config):base(config)
        {
            Users = new Users(this);
        }

        public IUsersApi Users { get; private set; }
    }
}