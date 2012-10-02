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
            Content = string.Format("We found the artist '{0}' on Last.fm. Click here to connect.", lastFmInfo.Name);
            CancelText = "No thanks";
            AcceptAction = "/api/v1/lastfm/connect/";
            Type = NotificationType.ConnectToLastFm;
        }
    }
}