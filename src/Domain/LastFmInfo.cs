using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Events;
using Infrastructure.DomainEvents;

namespace Domain
{
    public class LastFmInfo
    {
        public int Id { get; set; }
        public bool IsConnected { get; private set; }
        public string Bio { get; private set; }
        public string Name { get; private set; }
        public bool UseEvents { get; private set; }
        public bool UsePictures { get; private set; }
        public bool UseBio { get; private set; }

        [ForeignKey("Id")]
        [Required]
        public virtual Artist AssociatedArtist { get; set; }

        public void Update(string name, string bio)
        {
            Name = name;
            Bio = bio;
            DomainEvents.Raise(new LastFmInfoWasUpdated()
                                   {
                                       Info = this
                                   });
        }
        
        public static LastFmInfo Create(Artist artist, string name, string bio)
        {
            var lastFmInfo = new LastFmInfo()
                                 {
                                     AssociatedArtist = artist
                                 };
            
            lastFmInfo.Update(name, bio);
            return lastFmInfo;
        }

        public void Disconnect()
        {
            IsConnected = false;
        }

        public void Connect()
        {
            IsConnected = true;
            DomainEvents.Raise(new ArtistWasConnectedToLastFm()
                                   {
                                       LastFmInfo = this,
                                       Artist = AssociatedArtist
                                   });
        }

        public void UpdateSettings(bool useBio, bool useEvents, bool usePictures)
        {
            UseBio = useBio;
            UsePictures = usePictures;
            UseEvents = useEvents;
        }
    }
}