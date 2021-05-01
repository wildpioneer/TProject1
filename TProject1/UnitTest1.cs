using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TProject1
{
    public class Tests
    {
        private IWebDriver _driver;
        
        [SetUp]
        public void Setup()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            capabilities.SetCapability(CapabilityType.BrowserVersion, "89.0");
            capabilities.SetCapability("enableVNC", true);
            capabilities.SetCapability("enableVideo", true);
            
            _driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("http://tccit.mybb.ru/");
            Assert.AreEqual(_driver.Title, "Мстиславца 8");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}