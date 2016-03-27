using System;
using Bankapi.Exceptions;
using OpenQA.Selenium;

namespace Bankapi.Pekao24.Pages
{
    internal class MainPage : IDisposable
    {
        private readonly IWebDriver _webDriver;

        public MainPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string CustomerNumberInputValue
        {
            get
            {
                return GetCustomerNumberInput().GetAttribute("value");
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new InvalidCredentialsException(value);
                SetCustomerNumberInput(value);
            }
        }

        public string LoginButtonText => 
            GetLoginButton().GetAttribute("value");
        

        public EnterPasswordPage SubmitMainForm()
        {
            GetLoginButton().Click();
            return new EnterPasswordPage(_webDriver);
        }
           
        internal IWebElement GetCustomerNumberInput()
        {
            return _webDriver.FindElement(By.Id("parUsername"));
        }

        internal IWebElement GetLoginButton()
        {
            var loginButton = _webDriver.FindElement(By.Id("butLogin"));
            return loginButton;
        }

        private void SetCustomerNumberInput(string value)
        {
            var customerNumberInput = GetCustomerNumberInput();
            customerNumberInput.SendKeys(value);
        }

        public void Dispose()
        {
            _webDriver.Dispose();
        }
    }
}