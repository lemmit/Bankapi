using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace Bankapi.Pekao24.Pages
{
    internal class EnterPasswordPage
    {
        private readonly IWebDriver _webDriver;

        public EnterPasswordPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AccountsListPage ClickLoginButton()
        {
            return new AccountsListPage(_webDriver);
        }

        internal IEnumerable<IWebElement> GetLetters()
        {
            return _webDriver.FindElements(By.CssSelector("#accoutNumber > input"));
        }

        public string Password {
            get
            {
                string letters = null;
                try
                {
                    var lettersCollection = GetLetters();
                    letters = GetMaskedPasswordFromAvailableLetters(lettersCollection);
                }
                catch (Exception e)
                {
                    throw new Exception("Read password problem", e);
                }
                return letters;
            }
            set
            {
                try
                {
                    var letters = GetEnabledLetters();
                    SetInputsAccordinglyToPassword(value, letters);
                }
                catch (Exception e)
                {
                    throw new Exception("Fill password problem", e);
                }
            }
        }

        private string GetMaskedPasswordFromAvailableLetters(IEnumerable<IWebElement> lettersCollection)
        {
            var letters = "";
            foreach (var letter in lettersCollection)
            {
                var isDisabled = IsLetterDisabled(letter);
                letters += isDisabled ? "*" : letter.GetAttribute("value");
            }
            return letters;
        }

        private bool IsLetterDisabled(IWebElement letter)
        {
            return letter.GetAttribute("disabled").Equals("disabled");
        }

        private void SetInputsAccordinglyToPassword(string value, IEnumerable<IWebElement> letters)
        {
            foreach (var letter in letters)
            {
                var letterPosition = GetLetterPosition(letter);
                letter.SendKeys(value[letterPosition].ToString());
            }
        }

        private IEnumerable<IWebElement> GetEnabledLetters()
        {
            return GetLetters()
                .Where(letter => 
                    !letter.GetAttribute("disabled").Equals("disabled")
                );
        }

        private static int GetLetterPosition(IWebElement letter)
        {
            var name = letter.GetAttribute("name");
            return int.Parse(Regex.Match(name, "f\\d").Value);
        }
    }
}