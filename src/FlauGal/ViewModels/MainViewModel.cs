using FlauGal.Core;

namespace FlauGal.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public DirectoryListViewModel DirectoryList { get; set; }

        public int TileSize
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public FolderViewModel SelectedItem
        {
            get { return GetValue<FolderViewModel>(); }
            set
            {
                SetValue(value);
            }
        }

        public MainViewModel()
        {
            DirectoryList = new DirectoryListViewModel();
        }
    }
}
