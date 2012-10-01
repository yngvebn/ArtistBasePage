using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

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
        private UserLogin(string username, string password, Artist artist)
        {
            Username = username;
            Password = password;
            Created = DateTime.Now;
        }

        public UserLogin()
        {
            
        }

        public static UserLogin Create(string username, string password, Artist artist)
        {
            return new UserLogin(username, password, artist);
        }
    }
}