

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Autotest1
{
    class Demo
    {
        [Test]
        public static void TestYahoo()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            IWebElement inputField = chrome.FindElement(By.Id("login-username"));
            inputField.SendKeys("Test");
            IWebElement button = chrome.FindElement(By.Id("login-signin"));
            button.Click();
            //chrome.Quit(); 
        }
        [Test]
        public static void TestYahooWithFirefox()
        {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Url = "https://login.yahoo.com/";
            //IWebElement inputField = firefox.FindElement(By.Id("login-username"));
            IWebElement inputFieldByCssSelector = firefox.FindElement(By.CssSelector("#login-signin"));
            inputFieldByCssSelector.SendKeys("Test");
            IWebElement button = firefox.FindElement(By.Id("login-signin"));
            button.Click();
            firefox.Quit(); 
        }
        [Test]
        public static void TestSeleniumInputBlock()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";
            chrome.Manage().Window.Maximize();
            IWebElement inputField = chrome.FindElement(By.Id("user-message"));
            string myText = "Katinukai";
            inputField.SendKeys(myText);
            IWebElement button = chrome.FindElement(By.CssSelector("#get-input > button"));
            chrome.FindElement(By.Id("at-cv-lightbox-close")).Click();
            //IWebElement buttonByClass = chrome.FindElement(By.CssSelector(".btn.btn-default"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("display"));
            Assert.AreEqual(myText, result.Text, "Text is wrong");
            //Assert.IsTrue(myText.Equals(result), "Text is wrong");
            chrome.Quit();
        }


    }
}
