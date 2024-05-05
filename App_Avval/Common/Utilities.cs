using OpenQA.Selenium.Chrome;

namespace App_Avval.Common
{
    public static class Utilities
    {
        public static ChromeOptions getChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            //        chromeOptions.setProxy(seleniumProxy);
            //        chromeOptions.AddArguments("--user-agent=" + this.userAgent);
            ///chromeOptions.PageLoadStrategy(PageLoadStrategy.Normal);
            chromeOptions.AddArguments("--ignore-certificate-errors");
            chromeOptions.AddArguments("--ignore-ssl-errors=yes");
            ///chromeOptions.AcceptInsecureCerts(true);
            chromeOptions.AddArguments("--no-sandbox"); // https://stackoverflow.com/a/50725918/1689770
            chromeOptions.AddArguments("--disable-infobars"); // https://stackoverflow.com/a/43840128/1689770
            chromeOptions.AddArguments("--disable-dev-shm-usage"); // https://stackoverflow.com/a/50725918/1689770
            chromeOptions.AddArguments("--disable-browser-side-navigation"); // https://stackoverflow.com/a/49123152/1689770
            chromeOptions.AddArguments("--disable-gpu"); // https://stackoverflow.com/questions/51959986/how-to-solve-selenium-chromedriver-timed-out-receiving-message-from-renderer-exc
                                                         //        chromeOptions.setCapability("applicationCacheEnabled", false);
            chromeOptions.AddArguments("--disk-cache-size=0");
            chromeOptions.AddArguments("--disable-blink-features");
            chromeOptions.AddArguments("--disable-blink-features=AutomationControlled");
            chromeOptions.AddArguments("disable-infobars"); // disabling infobars
                                                            //        chromeOptions.AddArguments("--headless"); // Run in headless mode
                                                            //        chromeOptions.AddArguments("--remote-debugging-port=9323");
            var udr = File.Open("bdata/rubika", FileMode.Create);
            //if (udr. || udr.mkdirs())
            {
                //            if (systemConfig.isDevProfile()) {
                //                chromeOptions.AddArguments("--user-data-dir=/home/seluser" + udr.getPath());
                //            } else {
                chromeOptions.AddArguments("--user-data-dir=/home/seluser/" + udr.Name);
                chromeOptions.AddArguments("--profile-directory=Default");

                //            }
            }
            //else
            //{
            //    throw new RuntimeException("couldn't create udr");
            //}
            //        chromeOptions.setBinary("browser-simulation/110/" + (SystemUtils.OS_NAME.startsWith("Windows") ? "windows" : "linux") + "/binary/chrome" + (SystemUtils.OS_NAME.startsWith("Windows") ? ".exe" : ""));
            //        chromeOptions.setBinary("/opt/google/chrome/chrome");
            //        System.setProperty("webdriver.chrome.driver", "browser-simulation/110/" + (SystemUtils.OS_NAME.startsWith("Windows") ? "windows" : "linux") + "/driver" + (SystemUtils.OS_NAME.startsWith("Windows") ? ".exe" : ""));
            //        System.setProperty("webdriver.chrome.driver", "/usr/bin/chromedriver");
            // webBrowserDriverPath is a env variable set to "/usr/bin/geckodriver"
            //        System.setProperty("webdriver.gecko.driver", "/usr/bin/geckodriver");
            return chromeOptions;
        }


        public static string[] SpilitStrByLine(string str)
        {
            string[] lines = str.Split(
    new string[] { Environment.NewLine },
    StringSplitOptions.None
);
            return lines;
        }
    }
}
