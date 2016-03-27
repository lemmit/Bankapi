using Bankapi.Pekao24.Pages;
using OpenQA.Selenium.PhantomJS;

namespace Bankapi.Pekao24.Factories
{
    internal class MainPageFactory : IMainPageFactory
    {
        private const string BaseUrl = "https://www.pekao24.pl";
        public MainPage Create()
        {
            var webDriver = new PhantomJSDriver("Tools");
            webDriver.Navigate().GoToUrl(BaseUrl);
            return new MainPage(webDriver);
        }
    }
}
