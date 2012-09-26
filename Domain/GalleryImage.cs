using System;

namespace Domain
{
    public class GalleryImage
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Copyright { get; private set; }
        public string Photographer { get; private set; }
        public bool InGallery { get; private set; }
        public DateTime DateTaken { get; private set; }
        public DateTime Published { get; private set; }
    }
}