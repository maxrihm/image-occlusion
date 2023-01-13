using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Learn
{
    public class MainControl
    {
        State state;
        readonly MainWindow mainWindow;
        public enum State
        {
            Browser,
            Panel
        }
        
        public MainControl(MainWindow mw)
        {
            mainWindow = mw;
        }

        public void SetBrowser(string link) 
        {
            state = State.Browser;
            UpdateState();
            NavigateToLink(link);
        }

        public void SetPanel(string fileName) 
        {
            state = State.Panel;
            UpdateState();
            LoadImage(fileName);
        }

        void UpdateState() 
        {
            if (state == State.Browser) 
            {
                mainWindow.browser_control.Visibility = System.Windows.Visibility.Visible;

                mainWindow.panel_image.Visibility = System.Windows.Visibility.Hidden;
                mainWindow.scroll_control.Visibility=System.Windows.Visibility.Hidden;
            }
            else 
            {
                mainWindow.browser_control.Visibility = System.Windows.Visibility.Hidden;

                mainWindow.panel_image.Visibility = System.Windows.Visibility.Visible;
                mainWindow.scroll_control.Visibility = System.Windows.Visibility.Visible;
            }
        }

        void NavigateToLink(string link) 
        {
            mainWindow.browser_control.Load(link);
        }

        void LoadImage(string fileName) 
        {
            mainWindow.panel_image.Children.Clear();
            var image = new BitmapImage(new Uri(@$"{fileName}", UriKind.RelativeOrAbsolute));
            mainWindow.panel_image.Children.Add(new Image() { Source = image, Stretch = Stretch.None });
        }


    }
}
