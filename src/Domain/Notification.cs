namespace Domain
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public NotificationType Type { get; protected set; }

        public bool Read { get; set; }

        public string CancelText { get; set; }
        public string AcceptAction { get; set; }

    }

    public enum NotificationType
    {
        ConnectToLastFm = 1
    }
}