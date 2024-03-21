using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjSpecFlow.PageObjects
{
    public class AmazonHomePage
    {
        private readonly IWebDriver _driver;

        public AmazonHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Search(string query)
        {
            _driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(query + Keys.Enter);
        }
    }
}
