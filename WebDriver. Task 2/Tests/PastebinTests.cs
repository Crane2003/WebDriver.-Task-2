using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver._Task_2.Tests
{
    [TestClass]
    public class PastebinTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        private PastePage pastePage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            homePage = new HomePage(driver);
            pastePage = new PastePage(driver);
        }

        [TestMethod]
        public void CreateNewPaste_Test()
        {
            // Arrange
            string pasteText = @"git config --global user.name ""New Sheriff in Town""
git reset $(git commit-tree HEAD^{tree} -m ""Legacy code"")
git push origin master --force";
            string pasteExpiration = "10M";
            string pasteName = "how to gain dominance among developers";
            string syntaxHighlightingToSelect = "8";
            string syntaxHighlightingToCheck = "Bash";

            // Act
            homePage.Open();
            homePage.EnterPasteText(pasteText);
            homePage.SelectSyntaxHighlighting(syntaxHighlightingToSelect);
            homePage.SelectPasteExpiration(pasteExpiration);
            homePage.EnterPasteName(pasteName);
            homePage.CreateNewPaste();

            // Assert
            StringAssert.Contains(pastePage.GetPageTitle(), pasteName);
            Assert.AreEqual(NormalizeString(pasteText), NormalizeString(pastePage.GetPasteContent()));
            Assert.AreEqual(syntaxHighlightingToCheck, pastePage.GetSyntaxHighlighting());
        }

        /*method to normalize string, without method test fails: 
        Assert.AreEqual failed. Expected:<git config --global user.name "New Sheriff in Town"
        git reset $(git commit-tree HEAD^{tree} -m "Legacy code")
        git push origin master --force>. Actual:<git config --global user.name "New Sheriff in Town"
        git reset $(git commit-tree HEAD^{tree} -m "Legacy code")
        git push origin master --force>. 
         */
        private static string NormalizeString(string input)
        {
            return input.Replace("\r\n", "\n");
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
