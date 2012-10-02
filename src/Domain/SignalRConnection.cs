using System;

namespace Domain
{
    public class SignalRConnection
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public DateTime Updated { get; set; }
        public UserLogin UserLogin { get; set; }
        public static SignalRConnection Create(string connectionId, UserLogin user)
        {
            return new SignalRConnection()
                       {
                           ConnectionId = connectionId,
                           UserLogin = user,
                           Updated = DateTime.Now
                       };
        }
    }
}