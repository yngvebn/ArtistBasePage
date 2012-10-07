using System;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.Events;
using DotLastFm.Models;
using Infrastructure.DomainEvents;

namespace Domain
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Bio { get; private set; }

        public DateTime Created { get; private set; }

        public virtual Collection<ApiToken> ApiTokens { get; private set; } 
        public virtual Collection<UserLogin> Logins { get; private set; }
        public virtual Collection<GalleryImage> Gallery { get; private set; }
        public virtual Collection<Event> Events { get; private set; }
        public virtual Collection<Album> Albums { get; private set; }
        public virtual Collection<Article> News { get; private set; }
        public virtual Collection<SocialNetwork> SocialNetworks { get; private set; }
        public virtual Collection<Notification> Notifications { get; private set; }
        public virtual Collection<FacebookEvent> FacebookEvents { get; private set; } 
        public virtual LastFmInfo LastFmInfo { get; private set; }

        public void Update(Artist artist)
        {
            Email = artist.Email;
            Phone = artist.Phone;
            Name = artist.Name;
            Bio = artist.Bio;
        }

        public static Artist Create(string email)
        {
            return new Artist()
                {
                    Created = DateTime.Now,
                    Email = email
                };
        }

        public void SetSocialNetwork(SocialNetworkType type, string url)
        {
            if(SocialNetworks == null) SocialNetworks = new Collection<SocialNetwork>();
            var existing = SocialNetworks.SingleOrDefault(c => c.Type == type);
            if(existing != null)
            {
                existing.ChangeUrl(url);
            }
            else
            {
                SocialNetworks.Add(SocialNetwork.Create(type, url));
            }
        }


        public bool IsValidPassword(string username, string password)
        {
            return Logins.Any(c => c.Username == username && c.Password == password.Encrypt());
        }

        
        public void CreateLogon(string username, string password)
        {
            if(Logins == null) Logins = new Collection<UserLogin>();
            if (Logins.Any(c => c.Username == username)) throw new UserAlreadyExistsException(username);

            Logins.Add(UserLogin.Create(username, password.Encrypt(), this));
        }

        public void RemoveSocialNetwork(SocialNetworkType type)
        {
            SocialNetworks.Remove(SocialNetworks.SingleOrDefault(c => c.Type == type));
        }

        public void CreateAuthenticatedToken(Guid correlationId)
        {
            ApiTokens.Add(ApiToken.ReadWrite(this, correlationId));
        }

        public void CreateReadOnlyToken(Guid correlationId)
        {
            ApiTokens.Add(ApiToken.ReadOnly(this, correlationId));
        }

        public void UpdateLastFmInfo(string name, string bio)
        {
            if (LastFmInfo == null) 
                LastFmInfo = LastFmInfo.Create(this, name, bio);
            else
            {
                LastFmInfo.Update(name, bio);
            }
        }

        public void AddNotification(Notification connectToLastFmNotification)
        {
            if(Notifications == null) Notifications = new Collection<Notification>();
            if(Notifications.All(c => c.Type == connectToLastFmNotification.Type && !c.Read))
            {
                Notifications.Add(connectToLastFmNotification);    
                DomainEvents.Raise(new NotificationAdded()
                                       {
                                           Artist = this,
                                           LastNotification = connectToLastFmNotification
                                       });
            }
            
        }

        public void ConnectToLastFm()
        {
            LastFmInfo.Connect();
        }

        public void UpdateLastFmSettings(bool useBio, bool useEvents, bool usePictures)
        {
            LastFmInfo.UpdateSettings(useBio, useEvents);
            if (LastFmInfo.UseBio)
                Bio = LastFmInfo.Bio;
        }

        public void AddEvent(string title, DateTime start)
        {
            Events.Add(Event.Create(title, start));
        }

        public void AddFacebookEvent(string facebookId)
        {
            if (FacebookEvents.Any(c => c.FacebookId == facebookId))
                throw new FacebookEventAlreadyExistsException(facebookId);
            FacebookEvents.Add(FacebookEvent.Create(facebookId));
        }

        
    }
}