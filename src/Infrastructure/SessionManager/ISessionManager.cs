namespace Infrastructure.Commands
{
    public interface ISessionManager
    {
        SessionUsage OpenSession();
    }
}