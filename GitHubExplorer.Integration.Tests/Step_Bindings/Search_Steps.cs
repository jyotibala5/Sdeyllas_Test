using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubExplorer.Integration.Tests.Search_POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace GitHubExplorer.Integration.Tests.Step_Bindings
{[Binding]
    class Search_Steps
    {
        private IWebDriver driver;

        //IWebDriver driver;
        //private SearchPagePOM _SdesyllasSteps;

        [BeforeScenario]

        public void Setup()
        {
            string baseUrl = "http://localhost:52080/";
            driver = new ChromeDriver();
            driver.Url = baseUrl;
        }

        //public void SearchPageRequest()
        //{
        //    _SdesyllasSteps = new SearchPagePOM(driver);
        //}

        [Given(@"I am on the Search pages")]
        public void GivenIAmOnTheSearchPages()
        {
            SearchPagePOM SearchPage = new SearchPagePOM(driver);
            SearchPage.SearchHomePage();
        }

        [When(@"I search for the term ""(.*)""")]
        public void WhenISearchForTheTerm(string term)
        {
            SearchPagePOM SearchItem = new SearchPagePOM(driver);
            SearchItem.SearchItem(term);
            SearchItem.ClickSearch();
        }

        [Then(@"the user avatar is returned within the results")]
        public void ThenTheUserAvatarIsReturnedWithinTheResults()
        {
            SearchPagePOM VerifyPic = new SearchPagePOM(driver);
            VerifyPic.VerifyImage();
        }

        [Then(@"the user location is returned within the results")]
        public void ThenTheUserLocationIsReturnedWithinTheResults()
        {
            SearchPagePOM AssertLocation = new SearchPagePOM(driver);
            AssertLocation.Location();
        }

        [Then(@"the user top five repositories are returned within the results")]
        public void ThenTheUserTopFiveRepositoriesAreReturnedWithinTheResults()
        {
            SearchPagePOM AssertResults = new SearchPagePOM(driver);
            AssertResults.TopResults();
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

    }
}
