namespace Infrastructure.Commands
{
    public class SessionManager : ISessionManager
    {
        private readonly ISessionManagerInternal _manager;

        public SessionManager(ISessionManagerInternal manager)
        {
            _manager = manager;
        }
        public SessionUsage OpenSession()
        {
            return new SessionUsage(_manager);
        }
    }
}