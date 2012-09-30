using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Domain
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public string Bio { get; private set; }
        public virtual Collection<UserLogin> Logins { get; private set; }
        public virtual Collection<GalleryImage> Gallery { get; private set; }
        public virtual Collection<Event> Events { get; private set; }
        public virtual Collection<Album> Albums { get; private set; }
        public virtual Collection<Article> News { get; private set; }
        public virtual Collection<ApiSession> ApiSessions { get; private set; }
        public virtual Collection<SocialNetwork> SocialNetworks { get; private set; }


        public void Update(Artist artist)
        {
            Email = artist.Email;
            Phone = artist.Phone;
            Name = artist.Name;
            Bio = artist.Bio;
        }

        public ApiSession GetReadonlyToken()
        {
            ApiSession session = ApiSession.ReadOnly(this);
            ApiSessions.Add(session);
            return session;
        }
        public ApiSession GetReadWriteToken()
        {
            ApiSession session = ApiSession.ReadWrite(this);
            ApiSessions.Add(session);
            return session;

        }
        public static Artist Create(string email)
        {
            return new Artist()
                {
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

            Logins.Add(UserLogin.Create(username, password.Encrypt()));
        }

        public void RemoveSocialNetwork(SocialNetworkType type)
        {
            SocialNetworks.Remove(SocialNetworks.SingleOrDefault(c => c.Type == type));
        }
    }

    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string username)
            :base(string.Format("User with username {0} already exists", username))
        {
        }
    }

    public class UserLogin
    {
        public int Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public DateTime Created { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public static UserLogin Create(string username, string password)
        {
            return new UserLogin()
                       {
                           Username = username,
                           Password = password,
                           Created = DateTime.Now
                       };
        }
    }

    public static class StringExtensions
    {
        public static string Encrypt(this string text)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(text);
            data = x.ComputeHash(data);
            string md5Hash = System.Text.Encoding.ASCII.GetString(data);
            return md5Hash;
        }
    }
}