using System;

namespace Domain
{
    public class SignalRConnection
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public DateTime Updated { get; set; }
        public virtual UserLogin UserLogin { get; set; }
        public static SignalRConnection Create(string connectionId)
        {
            return new SignalRConnection()
                       {
                           ConnectionId = connectionId,
                           Updated = DateTime.Now
                       };
        }
    }
}