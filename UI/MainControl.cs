using System;

namespace Learn
{
    public class MainControl
    {
        private readonly MainWindow _mainWindow;
        private readonly IBrowser _browser;
        private readonly IPanel _panel;

        public MainControl(MainWindow mainWindow, IBrowser browser, IPanel panel)
        {
            _mainWindow = mainWindow;
            _browser = browser;
            _panel = panel;
        }

        public void SetBrowser(string link)
        {
            _browser.LoadLink(link);
            ShowBrowser();
        }

        public void SetPanel(string fileName)
        {
            _panel.LoadImage(fileName);
            ShowPanel();
        }

        private void ShowBrowser()
        {
            _mainWindow.browser_control.Visibility = System.Windows.Visibility.Visible;
            _mainWindow.panel_image.Visibility = System.Windows.Visibility.Hidden;
            _mainWindow.scroll_control.Visibility = System.Windows.Visibility.Hidden;
        }

        private void ShowPanel()
        {
            _mainWindow.browser_control.Visibility = System.Windows.Visibility.Hidden;
            _mainWindow.panel_image.Visibility = System.Windows.Visibility.Visible;
            _mainWindow.scroll_control.Visibility = System.Windows.Visibility.Visible;
        }
    }
}