using NUnit.Framework;
using NinjaPlus.Pages;
using NinjaPlus.Common;

namespace Ninjaplus.Tests
{
    public class LoginTests : BaseTest
    {

        private LoginPage _login;
        private Sidebar _side;

        [SetUp]
        public void Start()
        {

            _login = new LoginPage(Browser);
            _side = new Sidebar(Browser);
            
        }

        [Test]
        [Category("Critical")]
        public void ShouldSeeLoggedUser()
        {

            _login.With("tcm@ninjaplus.com", "pwd123");
            Assert.AreEqual("Neo", _side.loggedUser());

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