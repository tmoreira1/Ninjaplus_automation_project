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
        [Test]
        public void ShouldSeeIncorrectPass()
        {

            _login.With("tcm@ninjaplus.com", "ps4d12*&3");
            Assert.AreEqual("Usuário e/ou senha inválidos", _login.AlertMessage());

        }

        [Test]
        public void ShouldSeeIncorrectUser()
        {

            _login.With("Gih.maia@ninjaplus.com", "ps4d12*&3");
            Assert.AreEqual("Usuário e/ou senha inválidos", _login.AlertMessage());

        }

        [Test]
        public void ShouldSeeRequireEmail()
        {

            _login.With("", "ps4d12*&3");
            Assert.AreEqual("Opps. Cadê o email?", _login.AlertMessage());

        }

        [Test]
        public void ShouldSeeRequirePass()
        {

            _login.With("tcm@ninjaplus.com", "");
            Assert.AreEqual("Opps. Cadê a senha?", _login.AlertMessage());

        }
    }

}