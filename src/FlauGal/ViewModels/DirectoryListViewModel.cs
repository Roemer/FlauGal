using FlauGal.Models;
using System.Collections.ObjectModel;

namespace FlauGal.ViewModels
{
    public class DirectoryListViewModel
    {
        public ObservableCollection<FolderViewModel> Drives { get; set; }

        public DirectoryListViewModel()
        {
            Drives = new ObservableCollection<FolderViewModel>();
            foreach (var roots in GalleryDirectory.GetRootDirectories())
            {
                var drive = new FolderViewModel(roots);
                drive.LoadSubFolders(false);
                Drives.Add(drive);
            }
        }
    }
}
