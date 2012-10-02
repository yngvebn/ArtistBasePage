using System;

namespace Domain
{
    public class ApiToken
    {
        public int Id { get; set; }
        public DateTime Created { get; private set; }
        public DateTime Expires { get; private set; }
        public string Token { get; private set; }
        public Guid CorrelationId { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public virtual Artist AssociatedArtist { get; private set; }

        public bool IsValid
        {
            get { return Expires > DateTime.Now; }
        }

        public static ApiToken ReadOnly(Artist associatedArtist, Guid correlationId)
        {
            return new ApiToken()
                {
                    AssociatedArtist = associatedArtist,
                    Created = DateTime.Now,
                    Expires = DateTime.Now.AddDays(1),
                    IsAuthenticated = false,
                    Token = Guid.NewGuid().ToString("N"),
                    CorrelationId = correlationId
                };
        }

        public static ApiToken ReadWrite(Artist associatedArtist, Guid correlationId)
        {
            return new ApiToken()
            {
                AssociatedArtist = associatedArtist,
                Created = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                IsAuthenticated = true,
                Token = Guid.NewGuid().ToString("N"),
                CorrelationId = correlationId
            }; 
        }
    }
}