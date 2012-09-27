using System.Data.Entity;

namespace Infrastructure.Commands
{
    public interface ISessionManagerInternal
    {
        DbContext OpenSession();
        void ReleaseSession(DbContext session);
    }
}