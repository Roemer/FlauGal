using System.IO;

namespace FlauGal.Models
{
    public class GalleryImage
    {
        public string Name { get; set; }

        public string FullPath { get; set; }

        public string ContainingFolder { get; set; }

        public GalleryImage(string fullPath)
        {
            FullPath = fullPath;
            Name = Path.GetFileName(fullPath);
            ContainingFolder = Path.GetDirectoryName(fullPath);
        }
    }
}
