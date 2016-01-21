using System;
using System.Collections.Generic;

namespace CredPlus.Compartilhado.Events
{
    public class DomainEventNotifier
    {
        public static IEventContainer Container { get; set; }


        public static void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            try
            {
                if (Container != null)
                {
                    var handlers = Container.GetServices<T>();

                    foreach (var item in handlers)
                        ((IEventHandler<T>)item).Handle(domainEvent);
                }
            }
            catch (Exception)
            {
                //throw new RaiseEventException("Failed to raise event", ex);
            }
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
