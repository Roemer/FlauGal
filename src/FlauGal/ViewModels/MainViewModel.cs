using FlauGal.Core;

namespace FlauGal.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public DirectoryListViewModel DirectoryList { get; set; }

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
