using System.Collections.ObjectModel;

namespace Domain
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Facebook { get; private set; }
        public string Twitter { get; private set; }
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
    }
}