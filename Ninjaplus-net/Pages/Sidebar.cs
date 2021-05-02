using Coypu;

namespace NinjaPlus.Pages
{

    public class Sidebar
    {

        private readonly BrowserSession _browser;


        public Sidebar(BrowserSession browser)
        {
            _browser = browser;
        }

        public string loggedUser()
        {
           return _browser.FindCss(".user .info span").Text;
        }
    }
}