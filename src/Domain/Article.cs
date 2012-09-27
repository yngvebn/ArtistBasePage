using System;

namespace Domain
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public DateTime Published { get; private set; }
        public DateTime Updated { get; private set; }
        public bool IsDraft { get; private set; }
    }
}