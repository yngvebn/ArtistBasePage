using System.Collections.Generic;
using System.Data.Entity;

namespace Domain.Core
{
    public interface IArtistRepository
    {
        Artist Get(int id);
        Artist FindByEmail(string email);
        void Create(Artist artist);
        Artist FindByToken(string tokenKey);
    }
}