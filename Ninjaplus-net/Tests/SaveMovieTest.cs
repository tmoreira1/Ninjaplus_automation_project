using NUnit.Framework;
using NinjaPlus.Common;
using NinjaPlus.Pages;
using System.Threading;

namespace NinjaPlus.Tests
{

    public class SaveMovieTest : BaseTest
    {

        private LoginPage _login;
        private MoviePage _movie;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);
            _login.With("tcm@ninjaplus.com", "pwd123");
        }

        [Test]
        public void ShouldSaveMovie()
        {
           _movie.Add();
           _movie.Save("matrix reloaded", "Disponível");
           Thread.Sleep(5000);
        }
    }
}