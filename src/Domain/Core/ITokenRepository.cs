using System;

namespace Domain.Core
{
    public interface ITokenRepository
    {
        bool IsValid(string token);
        ApiToken Get(string token);
        ApiToken GetByCorrelationId(Guid correlationId);
    }
}