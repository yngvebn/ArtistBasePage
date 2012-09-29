using System.Collections.ObjectModel;

namespace Domain
{
    public class Artist
    {
        public int Id { get; set; }
        public string Username { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Facebook { get; private set; }
        public string Twitter { get; private set; }
        public string LinkedIn { get; private set; }
        public string LastFm { get; private set; }
        public string GooglePlus { get; private set; }
        public string Password { get; private set; }

        public string Bio { get; private set; }
        public virtual Collection<GalleryImage> Gallery { get; private set; }
        public virtual Collection<Event> Events { get; private set; }
        public virtual Collection<Album> Albums { get; private set; }
        public virtual Collection<Article> News { get; private set; }
        public virtual Collection<ApiSession> ApiSessions { get; private set; } 

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

        public void SetSocialNetwork(string facebook = null, string twitter = null, string linkedin = null, string lastfm = null, string googlePlus = null)
        {
            Facebook = facebook;
            Twitter = twitter;
            LinkedIn = linkedin;
            LastFm = lastfm;
            GooglePlus = googlePlus;
        }


        public bool IsValidPassword(string password)
        {
            return Password == Encrypt(password);
        }

        private string Encrypt(string text)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(text);
            data = x.ComputeHash(data);
            string md5Hash = System.Text.Encoding.ASCII.GetString(data);
            return md5Hash;
        }

        public void CreateLogon(string username, string password)
        {
            Password = Encrypt(password);
            Username = username;
        }


    }
}