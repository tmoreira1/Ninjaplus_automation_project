using NUnit.Framework;
using Coypu;
using Coypu.Drivers.Selenium;

namespace Ninjaplus.Tests
{
    public class OnAirTest
    {

        public BrowserSession browser;

        [SetUp]
        public void Setup()
        {

            var configs = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web",
                Port = 5000,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome

            };

            browser = new BrowserSession(configs);
            
        }

        [TearDown]
        public void Finish()
        {
            browser.Dispose();
        }

        [Test]
        [Category("Smoke")]
        public void ShouldBeHaveTitle()
        {
            
            browser.Visit("/login");
            Assert.AreEqual("Ninja+", browser.Title);

        }

    }
}