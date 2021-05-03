using System;
using Coypu;
using Coypu.Drivers.Selenium;
using NUnit.Framework;

namespace NinjaPlus.Common
{
    public class BaseTest
    {

        protected BrowserSession Browser;
        
        [SetUp]
        public void Setup()
        {

            var configs = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web",
                Port = 5000,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(10)

            };

            Browser = new BrowserSession(configs);

            Browser.MaximiseWindow();

            
        }

        [TearDown]
        public void Finish()
        {
            Browser.Dispose();
        }
    }
}