using System.Collections.Generic;
using System.Data.Entity;

namespace Domain.Core
{
    public interface IArtistRepository
    {
        Artist Get(int id);
        Artist FindByEmail(string email);
        void Create(Artist artist);
        IEnumerable<Artist> FindByUsername(string username);
        Artist FindByToken(string tokenKey);
    }
}