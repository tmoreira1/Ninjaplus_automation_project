using NUnit.Framework;
using Coypu;
using Coypu.Drivers.Selenium;
using System;
using NinjaPlus.Pages;

namespace Ninjaplus.Tests
{
    public class Logintests
    {

        public BrowserSession browser;

        private LoginPage _login;
        private Sidebar _side;

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

            browser = new BrowserSession(configs);

            browser.MaximiseWindow();

            _login = new LoginPage(browser);
            _side = new Sidebar(browser);
            
        }

        [TearDown]
        public void Finish()
        {
            browser.Dispose();
        }


        [Test]
        [Category("Critical")]
        public void ShouldSeeLoggedUser()
        {

            _login.With("tcm@ninjaplus.com", "pwd123");
            Assert.AreEqual("Thiago", _side.loggedUser());

        }
        
        [TestCase("tcm@ninjaplus.com", "ps4d12*&3", "Usuário e/ou senha inválidos")]
        [TestCase("Gih.maia@ninjaplus.com", "pwd123", "Usuário e/ou senha inválidos")]
        [TestCase("", "pwd123", "Opps. Cadê o email?")]
        [TestCase("Gih.maia@ninjaplus.com", "", "Opps. Cadê a senha?")]
        public void ShouldSeeAlertMessage(string email, string pass, string expectMessage)
        {

            _login.With(email, pass);
            Assert.AreEqual(expectMessage, _login.AlertMessage());

        }

    }

}