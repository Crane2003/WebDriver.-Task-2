using OpenQA.Selenium;

namespace WebDriver._Task_2
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private const string Url = "https://pastebin.com/";

        //pastebin allows to create only 10 pastes per day for unauthorized accounts,
        //this is url to paste to check "assert" part of the test (need to update the url)
        private const string UrlToPaste = "https://pastebin.com/ejQppNEe";

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement NewPasteTextArea => driver.FindElement(By.Id("postform-text"));
        private IWebElement PasteNameInput => driver.FindElement(By.Id("postform-name"));
        private IWebElement CreateNewPasteButton => driver.FindElement(By.XPath("//button[text()='Create New Paste']"));

        public void Open()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void EnterPasteText(string pasteText)
        {
            NewPasteTextArea.SendKeys(pasteText);
        }

        public void SelectPasteExpiration(string expirationValue)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"document.getElementById('postform-expiration').value = '{expirationValue}';");
        }

        public void EnterPasteName(string pasteName)
        {
            PasteNameInput.SendKeys(pasteName);
        }

        public void CreateNewPaste()
        {
            CreateNewPasteButton.Click();
        }

        public void SelectSyntaxHighlighting(string syntax)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"document.getElementById('postform-format').value = '{syntax}';");
        }
    }
}