using System.Collections.Generic;
using System.Linq;

namespace CredPlus.Compartilhado.Validations
{
    public abstract class Validatable
    {
        private List<Notification> _notifications;

        public bool IsValid
        {
            get
            {
                CreateNotificationListIfNull();
                Validate();
                return !HasNotifications();
            }
        }

        public Notification[] GetNotifications()
        {
            return _notifications.ToArray();
        }

        public string StringifyNotifications()
        {
            var notificacoes = _notifications.Where(x => x != null);
            return string.Join<string>(" || ", notificacoes.Select(x => x.Message));
        }

        protected void Notify(Notification notification)
        {
            CreateNotificationListIfNull();
            if (notification != null)
                _notifications.Add(notification);
        }

        protected void Notify(List<Notification> notifications)
        {
            CreateNotificationListIfNull();
            _notifications.AddRange(notifications.Where(x => x != null));
        }

        protected void Notify(params Notification[] notifications)
        {
            CreateNotificationListIfNull();
            if (notifications != null && notifications.Count() > 0)
                _notifications.AddRange(notifications.Where(x => x != null));
        }

        protected bool HasNotifications()
        {
            return _notifications.Any(x => x != null);
        }

        protected virtual void Validate() { }

        protected void Validations(params Notification[] values)
        {
            _notifications.AddRange(values.Where(x => x != null));
        }

        private void CreateNotificationListIfNull()
        {
            if (_notifications == null)
                _notifications = new List<Notification>();
        }
    }
}
