namespace Domain
{
    public class FacebookEvent
    {
        public int Id { get; set; }
        public string FacebookId { get; private set; }

        public static FacebookEvent Create(string facebookId)
        {
            return new FacebookEvent()
                       {
                           FacebookId = facebookId
                       };
        }
    }
}