using OpenQA.Selenium;

namespace WebDriver._Task_2
{
    public class PastePage
    {
        private readonly IWebDriver driver;

        public PastePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPasteContent()
        {
            var contentElements = driver.FindElements(By.CssSelector("div[class='de1']"));

            List<string> contentLines = [];
            foreach (var element in contentElements)
            {
                contentLines.Add(element.Text);
            }

            return string.Join("\n", contentLines);
        }

        public string GetSyntaxHighlighting()
        {
            return driver.FindElement(By.CssSelector("a[class='btn -small h_800']")).Text;
        }
    }
}
