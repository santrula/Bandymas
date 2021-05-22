# Bandymas
namespace Autotest1.Page
{
    public class VartuTechnikaPage
    {
        private static IWebDriver _driver;

        private IWebElement widthInputField => _driver.FindElement(By.Id("doors_width"));
        private IWebElement heightInputField => _driver.FindElement(By.Id("doors_height"));
        private IWebElement autoCheckBox => _driver.FindElement(By.Id("automatika"));
        private IWebElement worksCheckBox => _driver.FindElement(By.Id("darbai"));
        private IWebElement button => _driver.FindElement(By.Id("calc_submit"));
        private IWebElement resultElement = _driver.FindElement(By.CssSelector("#calc_result > div > strong"));

        public VartuTechnikaPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }

        public void InsertTextToWidthInput(string width)
        {
            widthInputField.Clear();
            widthInputField.SendKeys(width);
        }
        public void InsertTextToHeightInput(string height)
        {
            widthInputField.Clear();
            widthInputField.SendKeys(height);
        }
        public void InsertToBothFields(string width, string height)
        {
            InsertTextToWidthInput(width);
            InsertTextToHeightInput(height);
        }

        public void CheckAutomatikaCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != autoCheckBox.Selected)
            {
                autoCheckBox.Click();
            }

        }
        public void CheckDarbaiCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != worksCheckBox.Selected)
            {
                autoCheckBox.Click();
            }
        }
        public void ClickButton()
        {
            button.Click();
        }



        public void CheckResult(string result)
        {
            WaitForResult();
            Assert.IsTrue(resultElement.Text.Contains(result), $"Result is not correct, expected {result}, but was {resultElement.Text}");
        }

        private void WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.CssSelector("#calc_result > div > strong")).Displayed);
        }
        
    }
}
