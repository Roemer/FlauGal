using FlauGal.Models;

namespace FlauGal.ViewModels
{
    public class ImageViewModel
    {
        private readonly GalleryImage _model;

        public string FolderName { get { return _model.ContainingFolder; }}
        public string FileName { get { return _model.Name; } }
        public string FullPath { get { return _model.FullPath; } }

        public ImageViewModel(GalleryImage model)
        {
            _model = model;            
        }
    }
}
