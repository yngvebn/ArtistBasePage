namespace Domain
{
    public class SocialNetwork
    {
        public int Id { get; set; }
        public SocialNetworkType Type { get; private set; }
        public string Url { get; private set; }

        public static SocialNetwork Create(SocialNetworkType type, string url)
        {
            return new SocialNetwork()
                       {
                           Type = type, Url = url
                       };
        }

        public void ChangeUrl(string url)
        {
            Url = url;
        }
    }
}