using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProjSpecFlow.PageObjects;
using NUnit.Framework.Internal;

namespace TestProjSpecFlow.StepDefinitions
{
    [Binding]
    public class AmazonShoppingStepDefinitions
    {
        private IWebDriver _driver;
        private readonly AmazonHomePage _homePage;
        private readonly AmazonCartPage _cartPage;

        private readonly string _baseUrl = "https://www.amazon.com/";

        public AmazonShoppingStepDefinitions()
        {
            try
            {
                _driver = new ChromeDriver();
                _homePage = new AmazonHomePage(_driver);
                _cartPage = new AmazonCartPage(_driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing WebDriver: {ex}");
                throw;
            }
        }
        [Given(@"I navigate to Amazon.com as an unregistered user")]
        public void GivenINavigateToAmazonComAsAnUnregisteredUser()
        {
            _driver.Navigate().GoToUrl("https://www.amazon.com/");
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string item)
        {
            try
            {
                _homePage.Search(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching for item: {ex}");
                throw;
            }
        }

        [When(@"I add the item to the cart")]
        public void WhenIAddTheItemToTheCart()
        {
            try
            {
                _driver.FindElement(By.CssSelector("span.a-size-medium.a-color-base.a-text-normal")).Click();
                _driver.FindElement(By.Id("add-to-cart-button")).Click();
            }
            catch (NoSuchElementException ex)
            {
                throw;
            }
        }

        [When(@"I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            _driver.FindElement(By.Id("nav-cart-count")).Click();
        }

        [Then(@"I should see the correct item and amount in the cart")]
        public void ThenIShouldSeeTheCorrectItemAndAmountInTheCart()
        {
            string itemName = _cartPage.GetCartItemName();
            string itemPrice = _cartPage.GetCartItemPrice();

            Assert.IsTrue(itemName.Contains("TP-Link AC1200 Gigabit WiFi Router (Archer A6)"));
            Assert.IsTrue(itemPrice.Contains("$"));
        }

        [AfterScenario]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
