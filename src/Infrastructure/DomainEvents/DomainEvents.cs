using System;
using System.Collections.Generic;
using Ninject;

namespace Infrastructure.DomainEvents
{

    public static class DomainEvents
    {
        [ThreadStatic] //so that each thread has its own callbacks
        private static List<Delegate> _actions;


        public static void ClearCallbacks()
        {
            _actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (Container != null)
            {
                foreach (var handler in Container.GetAll<IHandleDomainEvent<T>>())
                    handler.Handle(args);
            }


            if (_actions != null)
            {
                foreach (Delegate action in _actions)
                {
                    if (action is Action<T>)
                        ((Action<T>)action)(args);
                }
            }
        }

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (_actions == null)
                _actions = new List<Delegate>();

            _actions.Add(callback);
        }

        public static IKernel Container { get; set; }
    }
}