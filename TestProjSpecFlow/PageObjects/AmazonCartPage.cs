using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjSpecFlow.PageObjects
{
    public class AmazonCartPage
    {
        private readonly IWebDriver _driver;

        public AmazonCartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetCartItemName()
        {
            return _driver.FindElement(By.CssSelector("span.a-truncate-cut")).Text;
        }

        public string GetCartItemPrice()
        {
            return _driver.FindElement(By.CssSelector("span.sc-price")).Text;
        }
    }
}
