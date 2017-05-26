﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibox.Automation
{
    public enum DriversOption
    {
        Chrome,
        InternetExplorer
    }
    public class Driver
    {
        //Permitirá obtener cualquier driver
        public static IWebDriver Instance { get; set; }

        public static void GetInstance(DriversOption option)
        {
            switch (option)
            {

                case DriversOption.Chrome:
                    Instance = ChromeInstance();
                    break;
                case DriversOption.InternetExplorer:
                    Instance = InternetExplorerInstance();
                    break;
                default:
                    Instance = null;
                    break;
            }
        }

        private static IWebDriver InternetExplorerInstance()
        {
            return new InternetExplorerDriver();
        }

        private static IWebDriver ChromeInstance()
        {
            var options = new ChromeOptions();
            options.AddArguments("chrome.switches", "--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            return  new ChromeDriver(options);
        }

        //Para cerrar la instancia y hacerla null
        public static void CloseInstance()
        {
            Instance.Close();
            Instance.Quit();
            Instance = null;
        }
    }
}
