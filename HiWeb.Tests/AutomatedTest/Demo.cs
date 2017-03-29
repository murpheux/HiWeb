using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Shouldly;

namespace HiWeb.Tests.AutomatedTest
{
    public class Demo : IDisposable
    {
        IWebDriver driver;

        public Demo()
        {
            var service = ChromeDriverService.CreateDefaultService(@"C:\Selenium\Drivers");

            //System.setProperty("webdriver.chrome.driver", "Path of &lt;chromedriver.exe&gt;");
            var options = new ChromeOptions();
            options.AddArguments("--test-type");

            driver = new ChromeDriver(service, options);
        }

        [Fact, Trait("Automated", "test")]
        void Test1()
        {
            driver.Navigate().GoToUrl("http://www.google.com/");

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Cheese");
            query.Submit();

            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 10 seconds
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

            // Should see: "Cheese - Google Search" (for an English locale)
           driver.Title.ShouldBe("Cheese - Google Search");

        }

        //~Demo()
        //{
        //    driver.Dispose();
        //}

        public void Dispose() => driver.Dispose();

    }
}
