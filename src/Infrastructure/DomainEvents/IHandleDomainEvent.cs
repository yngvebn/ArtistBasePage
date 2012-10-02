namespace Infrastructure.DomainEvents
{
    public interface IHandleDomainEvent<in T> where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}