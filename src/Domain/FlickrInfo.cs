using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class FlickrInfo
    {
        public int Id { get; set; }
        public bool IsConnected { get; private set; }
        public string Token { get; private set; }
        public string Secret { get; private set; }

        [ForeignKey("Id")]
        [Required]
        public virtual Artist AssociatedArtist { get; set; }

        public static FlickrInfo Connect(Artist artist, string token, string secret)
        {
            return new FlickrInfo()
                       {
                           AssociatedArtist = artist,
                           Token = token,
                           Secret = secret,
                           IsConnected = true
                       };
        }
    }
}