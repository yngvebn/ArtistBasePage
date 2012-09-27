using System;

namespace Domain.Core
{
    public interface ISession: IDisposable
    {
        Db Session { get; }
    }
}