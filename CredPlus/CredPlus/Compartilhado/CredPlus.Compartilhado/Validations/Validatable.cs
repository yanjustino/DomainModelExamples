using System.Collections.Generic;
using System.Linq;

namespace CredPlus.Compartilhado.Validations
{
    public class Validatable
    {
        private List<Notification> _notifications;

        public bool IsValid
        {
            get
            {
                CreateNotificationListIfNull();
                _notifications.Clear();
                Validate();
                return HasNotifications();
            }
        }

        public Notification[] GetNotifications()
        {
            return _notifications.ToArray();
        }

        public string StringifyNotifications()
        {
            return string.Join<string>(" || ", _notifications.Select(x => x.Message));
        }

        protected void Notify(Notification notification)
        {
            CreateNotificationListIfNull();
            _notifications.Add(notification);
        }

        protected void Notify(List<Notification> notifications)
        {
            CreateNotificationListIfNull();
            _notifications.AddRange(notifications);
        }

        protected void Notify(Notification[] notifications)
        {
            CreateNotificationListIfNull();
            _notifications.AddRange(notifications);
        }

        protected bool HasNotifications()
        {
            return _notifications.Any();
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
