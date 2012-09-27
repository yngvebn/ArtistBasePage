using System.Transactions;
using Ninject.Extensions.Interception;

namespace Infrastructure.Commands
{
    public class SessionAndTransactionWrapper : IInterceptor
    {
        private readonly ISessionManager _sessionManager;

        public SessionAndTransactionWrapper(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var session = _sessionManager.OpenSession())
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    invocation.Proceed();
                    session.Session.SaveChanges();
                    scope.Complete();
                }
            }
        }
    }
}