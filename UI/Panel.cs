using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Learn
{
    public class Panel : IPanel
    {
        private readonly Canvas _panelImage;

        public Panel(Canvas panelImage)
        {
            _panelImage = panelImage;
        }

        public void LoadImage(string fileName)
        {
            _panelImage.Children.Clear();
            var image = new BitmapImage(new Uri(@$"{fileName}", UriKind.RelativeOrAbsolute));
            _panelImage.Children.Add(new Image() { Source = image, Stretch = Stretch.None });
        }
    }
}