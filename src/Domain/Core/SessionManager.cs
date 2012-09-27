namespace Domain.Core
{
    public class SessionManager:ISessionManager
    {
        private readonly Db _db;

        public SessionManager(Db db)
        {
            _db = db;
        }

        public ISession OpenSession()
        {
            return new DbSession(_db);
        }

    }
}