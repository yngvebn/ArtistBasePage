namespace Domain
{
    public class ConnectToLastFmNotification: Notification
    {
        public ConnectToLastFmNotification()
        {
            
        }

        public ConnectToLastFmNotification(LastFmInfo lastFmInfo)
        {
            Title = "Connect to Last.fm";
            Content = string.Format("We found the artist '{0}' on Last.fm. Want to connect?", lastFmInfo.Name);
            Type = NotificationType.ConnectToLastFm;
        }
    }
}