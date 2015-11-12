﻿using System;
using Habitat.Accounts.Specflow.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace Habitat.Accounts.Specflow.Steps
{
    [Binding]
    public class StepsBase
    {
        public static IWebDriver Driver
        {
            get { return FeatureContext.Current.Get<IWebDriver>(); }
            set { FeatureContext.Current.Set(value); }
        }

        [BeforeFeature]
        public static void Setup()
        {
            Driver = new FirefoxDriver();
        }

        public Site Site => new Site();

        [AfterFeature]
        public static void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}