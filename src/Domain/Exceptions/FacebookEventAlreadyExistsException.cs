using System;

namespace Domain
{
    public class FacebookEventAlreadyExistsException : Exception
    {
        public FacebookEventAlreadyExistsException(string facebookId)
            :base(string.Format("The facebook event with id {0} is already added", facebookId))
        {
            
        }
    }
}