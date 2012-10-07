using System;

namespace Domain
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string username)
            :base(string.Format("User with username {0} already exists", username))
        {
        }
    }
}