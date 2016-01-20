namespace CredPlus.Compartilhado.Events
{
    public interface IEventHandler<T> where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}
