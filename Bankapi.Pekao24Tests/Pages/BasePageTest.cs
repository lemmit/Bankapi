using System;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace Bankapi.Pekao24Tests.Pages
{
    public abstract class BasePageTest : IDisposable
    {
        protected readonly string BaseUrl = 
            "file:///"
            + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/")
            + "/Pekao24/";

        protected IWebDriver WebDriver;
        protected BasePageTest()
        {
            WebDriver = new PhantomJSDriver("Tools");
        }

        public void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}
