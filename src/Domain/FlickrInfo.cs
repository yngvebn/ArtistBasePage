using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class FlickrInfo
    {
        public int Id { get; set; }
        public bool IsConnected { get; private set; }
        public string RequestToken { get; private set; }
        public string RequestSecret { get; private set; }
        public string Token { get; private set; }
        public string Secret { get; private set; }

        [ForeignKey("Id")]
        [Required]
        public virtual Artist AssociatedArtist { get; set; }

        public static FlickrInfo Create(Artist artist, string requestToken, string requestSecret)
        {
            return new FlickrInfo()
                       {
                           IsConnected = false,
                           RequestSecret = requestSecret,
                           RequestToken = requestToken
                       };
        }

        public void Connect(string token, string secret)
        {
            Token = token;
            Secret = secret;
            IsConnected = true;
        }

        public void Update(string token, string secret)
        {
            RequestToken = token;
            RequestSecret = secret;
        }
    }
}