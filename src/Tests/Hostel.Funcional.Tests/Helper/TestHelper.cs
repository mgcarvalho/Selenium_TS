﻿using Hostel.Funcional.Tests.Enum;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;

namespace Hostel.Funcional.Tests.Helper
{
    public static class TestHelper
    {
        #region Const
        public const int waitSeconds = 10;
        public const string principalURI = "https://www.mobilityfriendshostel.pt/";
        #endregion

        public static IWebDriver Create(Browser browserSelection = Browser.Chrome)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //Will need to construct the remoteServerUri so it can be passed to the remoteWebDriver.
            //var remoteServer = BuildRemoteServer(configuration.SeleniumHubUrl, configuration.SeleniumHubPort);
            WebDriver _driver = null;
            switch (browserSelection)
            {
                case Browser.Chrome:
                    ChromeOptions coptions = new ChromeOptions();
                    TimeSpan timeout = new TimeSpan(0, 0, waitSeconds);
                    coptions.AddArguments("--no-sandbox");
                    coptions.AddArguments("--enable-features=NetworkService,NetworkServiceInProcess");
                    coptions.AddArguments("incognito");
                    coptions.AddArguments("start-maximized");
                    coptions.AcceptInsecureCertificates = true;
                    //coptions.AddArguments("--remote - debugging - port = 4445");
                    _driver = new ChromeDriver(baseDirectory, coptions, timeout);
                    _driver.Url = principalURI;
                    _driver.Navigate();
                    break;

                case Browser.InternetExplorer:
                    _driver = new InternetExplorerDriver(baseDirectory, new InternetExplorerOptions());
                    _driver.Url = principalURI;
                    _driver.Navigate();
                    break;

                case Browser.Edge:
                    _driver = new InternetExplorerDriver(baseDirectory, new InternetExplorerOptions());
                    _driver.Url = principalURI;
                    _driver.Navigate();
                    break;
            }

            return _driver;
        }

    }
}