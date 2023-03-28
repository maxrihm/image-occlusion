using System.Windows.Controls;

namespace Learn
{
    public class Browser : IBrowser
    {
        private readonly WebBrowser _webBrowser;

        public Browser(WebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
        }

        public void LoadLink(string link)
        {
            _webBrowser.Load(link);
        }
    }
}