using System.Collections;
using System.Collections.Generic;

namespace Hyper.Web.Validation
{
    public abstract class Validation
    {
        public Validation() => _notifications = new List<Notification>();
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        private readonly List<Notification> _notifications;
        public void AddNotification(string code, string message)
        {
            _notifications.Add(new Notification(code, message));
        }

        public bool Invalid => _notifications.Count > 0;
        public bool Valid => !Invalid;

    }

    public sealed class Notification 
    {
        public Notification(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; private set; }
        public string Message { get; private set; }
    }
}