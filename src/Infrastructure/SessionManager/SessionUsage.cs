using System;
using System.Data.Entity;

namespace Infrastructure.Commands
{
    public class SessionUsage : IDisposable
    {
        private ISessionManagerInternal InternalManager { get; set; }

        public SessionUsage(ISessionManagerInternal sessionManager)
        {
            InternalManager = sessionManager;
            Session = sessionManager.OpenSession();
        }

        public DbContext Session { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            // InternalManager.ReleaseSession(Session);
            if (isDisposing)
            {
                Session = null;
                InternalManager = null;
            }
        }

        ~SessionUsage()
        {
            Dispose(false);
        }
    }
}