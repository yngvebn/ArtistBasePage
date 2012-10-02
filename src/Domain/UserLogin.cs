using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public virtual Collection<Artist> Artists { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public virtual Collection<SignalRConnection> SignalRConnections { get; private set; }
        private UserLogin(string username, string password)
        {
            Username = username;
            Password = password.Encrypt();
            Created = DateTime.Now;
        }

        public void AddArtist(Artist artist)
        {
            if (Artists == null) Artists = new Collection<Artist>();
            Artists.Add(artist);
        }

        public UserLogin()
        {
            
        }

        public static UserLogin Create(string username, string password, Artist artist = null)
        {
            var userLogin = new UserLogin(username, password);
            
            if(artist != null) userLogin.AddArtist(artist);
            return userLogin;
        }

        public void ConnectWithSignalR(string connectionId)
        {
            if(SignalRConnections == null) SignalRConnections = new Collection<SignalRConnection>();
            SignalRConnections.Add(SignalRConnection.Create(connectionId, this));
        }

        public void DisconnectWithSignalR(string connectionId)
        {
            if (SignalRConnections == null) SignalRConnections = new Collection<SignalRConnection>();
            SignalRConnections.Remove(SignalRConnections.SingleOrDefault(c => c.ConnectionId == connectionId));
        }
    }
}