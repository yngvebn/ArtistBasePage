using System.Transactions;

namespace Domain.Core
{
    public class DbSession: ISession
    {

        private readonly Db _db;
        private readonly TransactionScope _scope;
        public DbSession(Db db)
        {
            _scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });
            _db = db;
        }
        public Db Session { get { return _db; } }

        public void Dispose()
        {
            _db.SaveChanges();
            _scope.Complete();
            _scope.Dispose();
        }
    }
}