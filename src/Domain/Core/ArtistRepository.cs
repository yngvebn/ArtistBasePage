using System;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using Ninject;
using Ninject.Extensions.Interception;

namespace Domain.Core
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ISessionManager _sessionManager;

        public ArtistRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public Artist Get(int id)
        {
            using (var session = _sessionManager.OpenSession())
            {
                return session.Session.Set<Artist>().Find(id);
            }
        }

        public Artist FindByEmail(string email)
        {
            using (var session = _sessionManager.OpenSession())
            {
                return session.Session.Set<Artist>().SingleOrDefault(c => c.Email == email);
            }
        }

        public void Create(Artist artist)
        {
            using(var session = _sessionManager.OpenSession())
            {
                session.Session.Set<Artist>().Add(artist);
                
            }
        }
    }

    public class CommandExecutor : ICommandExecutor
    {
        private readonly IKernel _kernel;

        public CommandExecutor(IKernel kernel)
        {
            _kernel = kernel;
        }

        public CommandResult ExecuteCommand(Command command)
        {
            dynamic handler = FindHandlerForCommand(command);

            try
            {
                handler.Handle(command as dynamic);
                return CommandResult.Executed("Command executed successfully");
            }
            finally
            {
                _kernel.Release(handler);
            }
        }

        private object FindHandlerForCommand(Command command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = _kernel.Get(handlerType);
            return handler;
        }
    }

    public interface ICommandExecutor
    {
        CommandResult ExecuteCommand(Command command);
    }

    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }

    public abstract class Command
    {

    }

    public class CommandResult
    {
        public static CommandResult Executed(string message)
        {
            return new CommandResult { Status = CommandStatus.Executed, Message = message };
        }

        public static CommandResult Failed(string message)
        {
            return new CommandResult { Status = CommandStatus.Failed, Message = message };
        }

        public bool IsExecuted
        {
            get { return Status == CommandStatus.Executed; }
        }

        public string Message { get; set; }

        public CommandStatus Status { get; set; }
    }

    public enum CommandStatus
    {
        Executed,
        Failed,
        Invalid
    }

    public interface ISessionManager
    {
        SessionUsage OpenSession();
    }

    public class SessionAndTransactionWrapper: IInterceptor
    {
        private readonly ISessionManager _sessionManager;

        public SessionAndTransactionWrapper(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void Intercept(IInvocation invocation)
        {
            using(var session = _sessionManager.OpenSession())
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

    public class SessionManager: ISessionManager
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

    public class SessionUsage: IDisposable
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
            if(isDisposing)
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


    public interface ISessionManagerInternal
    {
        DbContext OpenSession();
        void ReleaseSession(DbContext session);
    }
}