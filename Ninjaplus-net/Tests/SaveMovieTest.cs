using NUnit.Framework;
using NinjaPlus.Common;
using NinjaPlus.Pages;
using System.Threading;
using NinjaPlus.Models;
using NinjaPlus.Lib;
using System;

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

            var movieData = new MovieModel()
            {
                Title = "matrix reloaded",
                Status = "Disponível",
                Year = 2003,
                ReleaseDate = "28/09/2003",
                Cast = {"Keanu Reeves", "Carrie-Anne Moss", "Hugo Weaving", "Laurence Fishburne"},
                Plot = "Após derrotar as máquinas em seu combate inicial, Neo ainda vive na Nabucodonosor ao lado de Morpheus, Trinity e Link, o novo tripulante da nave.",
                Cover = CoverPath() + "capMatrixreload.jpg"
            };

            Database.RemoveByTitle(movieData.Title);

           _movie.Add();
           _movie.Save(movieData);
        
            
            Assert.That(_movie.HasMovie(movieData.Title),
             $"Erro ao verifricar se o filme {movieData} foi cadastrado."
             );

        }
    }
}