using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace App_Avval
{
    public class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        public AutomatedUITests() => _driver = new ChromeDriver();
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
