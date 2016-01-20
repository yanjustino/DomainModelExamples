using System.Collections.Generic;

namespace CredPlus.Compartilhado.Events
{
    public class DomainEventNotifier
    {
        private static DomainEventNotifier _current;
        public static DomainEventNotifier Current
        {
            get
            {
                _current = _current ?? new DomainEventNotifier();
                return _current;
            }
        }

        private List<IEventHandler<IDomainEvent>> _handlers;

        public void Register(IEventHandler<IDomainEvent> handler)
        {
            if (_handlers == null)
                _handlers = new List<IEventHandler<IDomainEvent>>();

            _handlers.Add(handler);

        }

        public void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            foreach (var handler in _handlers)
                Execute(domainEvent, handler);
        }

        private void Execute<T>(T domainEvent, IEventHandler<T> handler) where T : IDomainEvent
        {
            try
            {
                handler.Handle(domainEvent);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
