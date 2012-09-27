using System;

namespace Domain
{
    public class ApiSession
    {
        public int Id { get; set; }
        public DateTime Created { get; private set; }
        public DateTime Expires { get; private set; }
        public string Token { get; private set; }
        public bool Read { get; private set; }
        public bool Write { get; private set; }
        public virtual Artist AuthenticatedArtist { get; private set; }

        public static ApiSession ReadOnly(Artist authenticatedArtist)
        {
            return new ApiSession()
                {
                    AuthenticatedArtist = authenticatedArtist,
                    Created = DateTime.Now,
                    Expires = DateTime.Now.AddDays(1),
                    Read = true,
                    Write = false,
                    Token = Guid.NewGuid().ToString("N")
                };
        }

        public static ApiSession ReadWrite(Artist authenticatedArtist)
        {
            return new ApiSession()
            {
                AuthenticatedArtist = authenticatedArtist,
                Created = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                Read = true,
                Write = true,
                Token = Guid.NewGuid().ToString("N")
            }; 
        }
    }
}