using Coypu;
using NinjaPlus.Models;

namespace NinjaPlus.Pages
{

    public class MoviePage
    {

        private readonly BrowserSession _browser;

        public MoviePage(BrowserSession browser)
        {
            _browser = browser;
        }
        public void Add()
        {
            _browser.FindCss(".movie-add").Click();
        }

        public void SelectStatus(string status)
        {
            _browser.FindCss("input[placeholder=Status]").Click();
            var option = _browser.FindCss("ul li span", text: status);
            option.Click();

        }

        public void Save(MovieModel movie)
        {
            _browser.FindCss("input[name=title]").SendKeys(movie.Title);
            SelectStatus(movie.Status);
            _browser.FindCss("input[name=year]").SendKeys(movie.Year.ToString());
            _browser.FindCss("input[name=release_date]").SendKeys(movie.ReleaseDate);
            _browser.FindCss("textarea[name=overview]").SendKeys(movie.Plot);
        }
    }
}