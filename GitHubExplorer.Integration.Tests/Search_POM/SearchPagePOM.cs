using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GitHubExplorer.Integration.Tests.Search_POM
{
    class SearchPagePOM
    {
        IWebDriver driver;

        public SearchPagePOM(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //Locators

        [FindsBy(How = How.TagName, Using = "body")]
        public IWebElement SearchPage;

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement SearchBox;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.body-content > div > div > form > span > button")]
        public IWebElement Search;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.body-content > div:nth-child(4) > div > p:nth-child(2) > img")]
        public IWebElement Image;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.body-content > div:nth-child(4) > div > p:nth-child(3)")]
        public IWebElement Findlocation;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.body-content > div:nth-child(4) > div > h3")]
        public IWebElement Resultsheader;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.body-content")]
        public IWebElement Results;


        //Methods
        public void SearchHomePage()
        {
            string BodyText = this.SearchPage.Text;
            Assert.That(BodyText.Contains("Search User"));
        }

        public void SearchItem(string searchTerm)
        {
            SearchBox.SendKeys(searchTerm);
            Assert.IsNotNull(searchTerm);

        }

        public void ClickSearch()
        {
            Assert.IsNotNull(Search);
            Search.Click();

        }

        public void VerifyImage()
        {
            Assert.IsNotNull(Image);
        }

        public void Location()
        {
            var locationdisplay = Findlocation.Text;
            Assert.AreEqual(locationdisplay, "London, UK");
        }

        public void ResultsVerify()
        {
            var resultsheading = Resultsheader.Text;
            Assert.AreEqual(resultsheading, "Top 5 repositories");

        }

        public void TopResults()
        {

            var resval = Results.Text;

            Assert.Multiple(() =>
            {
                Assert.That(resval.Contains("RiotApi.NET"));
                Assert.That(resval.Contains("MailChimp.Net"));
                Assert.That(resval.Contains("LoLUniverse"));
                Assert.That(resval.Contains("github-explorer"));
                Assert.That(resval.Contains("LolUniverse-Android"));

            });

        }
    }
}
