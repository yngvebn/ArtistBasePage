namespace Domain.Core
{
    public interface ISessionManager
    {
        ISession OpenSession();
    }
}