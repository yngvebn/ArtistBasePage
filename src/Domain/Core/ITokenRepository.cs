namespace Domain.Core
{
    public interface ITokenRepository
    {
        bool IsValid(string token);
        ApiSession Get(string token);
    }
}