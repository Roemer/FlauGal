using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FlauGal.Controls
{
    /// <summary>
    /// Interaction logic for AsyncImage.xaml
    /// </summary>
    public partial class AsyncImage : UserControl
    {
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(AsyncImage), new UIPropertyMetadata("", OnImageSourceChanged));

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        private static readonly object LockObject = new object();
        private static readonly SemaphoreSlim ConcurrencySemaphore = new SemaphoreSlim(20);

        public AsyncImage()
        {
            InitializeComponent();
        }

        protected async void ShowImageAsync(string source)
        {
            Img.Source = await LoadImageSourceAsync(source);
            Busy.Visibility = Visibility.Collapsed;
        }

        private async Task<ImageSource> LoadImageSourceAsync(string address)
        {
            await ConcurrencySemaphore.WaitAsync();
            var img = await Task.Run(() =>
            {
                lock (LockObject)
                {
                    var size = 100;
                    var bi = new BitmapImage();
                    bi.BeginInit();
                    bi.DecodePixelWidth = size;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.UriSource = new Uri(address);
                    bi.EndInit();
                    bi.Freeze();
                    return bi;
                }
            });
            ConcurrencySemaphore.Release();
            return img;
        }

        private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var v = d as AsyncImage;
            if (v == null)
            {
                return;
            }
            v.ShowImageAsync(e.NewValue.ToString());
        }
    }
}
