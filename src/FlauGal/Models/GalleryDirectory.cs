using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FlauGal.Models
{
    public class GalleryDirectory
    {
        public string Name { get; set; }

        public string FullPath { get; set; }

        public bool IsRoot
        {
            get { return FullPath.EndsWith(@":\"); }
        }

        public GalleryDirectory(string fullPath)
        {
            FullPath = fullPath;
            Name = IsRoot ? fullPath : Path.GetFileName(fullPath);
        }

        public List<GalleryDirectory> GetSubDirectories()
        {
            var subDirs = new List<GalleryDirectory>();
            try
            {
                foreach (var subFolderPath in Directory.GetDirectories(FullPath))
                {
                    var subFolder = new GalleryDirectory(subFolderPath);
                    subDirs.Add(subFolder);
                }
            }
            catch (Exception ex) { }
            return subDirs;
        }

        public async Task<List<GalleryImage>> GetImages()
        {
            var images = new List<GalleryImage>();
            await Task.Run(() =>
            {
                foreach (var img in Directory.GetFiles(FullPath, "*.jpg", SearchOption.AllDirectories))
                {
                    var galImg = new GalleryImage(img);
                    images.Add(galImg);
                }
            });
            return images;
        }

        public static List<GalleryDirectory> GetRootDirectories()
        {
            var roots = new List<GalleryDirectory>();
            foreach (var drivePath in Directory.GetLogicalDrives())
            {
                var drive = new GalleryDirectory(drivePath);
                roots.Add(drive);
            }
            return roots;
        }
    }
}
