using App_Avval.Models;
using App_Avval.Models.Context;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V115.CSS;
using OpenQA.Selenium.DevTools.V117.Network;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App_Avval.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebDriver _driver;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> ReadKeyword()
        {


            ReadKeywordForId(0, 2400);

            return View();
        }

        public ChromeOptions loadcoockie(string mobile)
        {
            ChromeOptions chromeOptions = new ChromeOptions();

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
            if (mobile == "9361798086")
                chromeOptions.AddArguments(@"user-data-dir=C:\Users\s.tohidi\AppData\Local\Google\Chrome\User Data\coockietohidi");
            if (mobile == "9214560765")
                chromeOptions.AddArguments(@"user-data-dir=C:\Users\s.tohidi\AppData\Local\Google\Chrome\User Data\coockiejavadi");

            //chromeOptions.AddArguments("--user-data-dir=/home/seluser/" + udr.Name);
            //chromeOptions.AddArguments("--profile-directory=Default");
            return chromeOptions;

        }
        public void ReadKeywordForId(int idMin, int idMax)
        {
            var rubikaURL = "https://web.rubika.ir/";
            //var mobile = "9361798086";
            var mobile = "9214560765";
            ChromeOptions options = new ChromeOptions();
            options = loadcoockie(mobile);
            try
            {
                IWebDriver driver = new ChromeDriver(@"E:\Tohidi\Projects\Avval\Avval\App_Avval\App_Avval\driver\driver123\", options);

                driver.Navigate().GoToUrl(rubikaURL);

                //IWebElement input_el = driver.FindElement(By.Name("phone_number"));
                //input_el.SendKeys(mobile);
                ////input_el.SendKeys(mobile);
                //IWebElement button_el = driver.FindElement(By.TagName("button"));
                //button_el.Click();
                ////phone_code
                ////Thread.Sleep(15000);
                //var code = System.IO.File.ReadAllText("code.txt");
                //IWebElement code_el = driver.FindElement(By.Name("phone_code"));
                //code_el.SendKeys(code);
                //WebDriverWait _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
                //_webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(webDriver.FindElement(By.Name("phone_code")), code));
                //Thread.Sleep(15000);
                //driver.Navigate().Refresh();
                var htmlnew = driver.PageSource;
                //ReadOnlyCollection<OpenQA.Selenium.Cookie> cc = driver.Manage().Cookies.AllCookies;
                //foreach (var item in cc)
                //{
                //    driver.Manage().Cookies.AddCookie(item);
                //}
                //driver.Manage().Window.Minimize();  
                //driver.ExecuteJavaScript("return document.hidden;");

                //var file_keywords = "E:\\Tohidi\\Projects\\Avval\\Avval\\App_Avval\\App_Avval\\keywords.txt"; 
                //var file_keywords = "E:\\Tohidi\\Projects\\Avval\\Avval\\App_Avval\\App_Avval\\keywordsAll.csv"; 
                //string[] keywords = System.IO.File.ReadAllLines(file_keywords);
                //var keywords = _dbContext.RubikaKeywords.Where(w => w.VisitedDate == null && w.Name.Length > 2 && w.Id <= idMax && w.Id >= idMin).ToList();
                //fnRemoveChannel(driver);
                Loop:
                var keywords = _dbContext.RubikaKeywords.Where(w =>w.Type == 3 && w.Name != null).ToList();
                var keywordsMaster = _dbContext.RubikaKeywords.Where(w =>w.Type == 6 && w.VisitedDate == null && w.Name != null).ToList();


                int countchannel = 0;
                int CountLoop = 0;
                List<string> erorrMessages = new List<string>();
                try
                {
                    //23180
                    foreach (var txt in keywordsMaster)
                    { 
                        countchannel=0;
                        driver.Navigate().Refresh();
                        foreach (var txt2 in keywords)
                        //for (int m = 0; m < 1000000; m++)
                        {
                            //11402
                            
                            //var key1 = keywords.OrderBy(w => Guid.NewGuid()).FirstOrDefault();
                            //var key2 = keywords.OrderBy(w => Guid.NewGuid()).FirstOrDefault();
                            var keyword = txt.Name + " " + txt2.Name;
                            //var keyword = txt.Name;
                            int count = 0;
                            try
                            {

                                if (countchannel > 100)
                                {
                                    countchannel = 0;
                                    break;
                                    fnRemoveChannel(driver);
                                    driver.Navigate().Refresh();
                                }

                                try
                                {

                                    // active 
                                    var li = driver.FindElements(By.TagName("li"));
                                    for (int n = 1; n < li.Count(); n++)
                                    {
                                        try
                                        {

                                            Actions actions = new Actions(driver);
                                            li[n].Click();
                                            Thread.Sleep(1000);
                                            driver.FindElement(By.ClassName("chat-info-container")).Click();
                                            break;
                                        }
                                        catch (Exception ex)
                                        {

                                            var tt = ex.Message;
                                        }
                                    }

                                }
                                catch (Exception)
                                {


                                }

                                // Search
                                IWebElement input_search = driver.FindElement(By.ClassName("input-search")).FindElement(By.TagName("input"));
                                input_search.Clear();
                                input_search.SendKeys(keyword);
                                input_search.Click();
                                Thread.Sleep(1000);

                                int i = 0;
                                // Read Menu
                                List<IWebElement> messages = driver.FindElement(By.ClassName("im_dialogs_contacts_wrap")).FindElements(By.TagName("li")).ToList();


                                if (messages.Any())
                                    foreach (var message in messages)
                                    {
                                        try
                                        {
                                            // Search
                                            IWebElement input_search_Repeated = driver.FindElement(By.ClassName("input-search")).FindElement(By.TagName("input"));
                                            input_search_Repeated.Clear();
                                            input_search_Repeated.SendKeys(keyword);
                                            input_search_Repeated.Click();
                                            Thread.Sleep(1000);
                                            List<IWebElement> temp_messages = driver.FindElement(By.ClassName("im_dialogs_contacts_wrap")).FindElements(By.TagName("li")).ToList();

                                            Thread.Sleep(1000);
                                            if (temp_messages.Any())
                                            {
                                                Actions action = new Actions(driver);
                                                bool clicked = true;
                                                try
                                                {
                                                    action.MoveToElement(temp_messages[i]).Click().Perform();

                                                    //driver.FindElement(By.ClassName("chat-info-container")).Click();
                                                }
                                                catch (Exception)
                                                {
                                                    clicked = false;
                                                }
                                                if (!clicked)
                                                {
                                                    temp_messages[i].Click();
                                                }

                                                //var mId = message.GetAttribute("data-msg-id");
                                                //var msg = message.Text;
                                                //var date = message.FindElement(By.TagName("span")).Text;
                                                //Thread.Sleep(1000);
                                                //driver.FindElement(By.ClassName("chat-info-container")).Click();
                                                Thread.Sleep(1000);
                                                var resultConvert = ConvertRubikaHtmlToModel(driver, txt.Name);
                                                if (resultConvert)
                                                    countchannel++;
                                            }
                                            i++;


                                        }
                                        catch (Exception ex)
                                        {
                                            erorrMessages.Add(ex.Message);
                                            i++;
                                        }
                                    }


                                txt.VisitedDate = DateTime.Now;
                                txt.Count = count;
                                _dbContext.Update(txt);
                                _dbContext.SaveChanges();

                                //countchannel = countchannel + count;

                            }
                            catch (Exception ex)
                            {
                                erorrMessages.Add(ex.Message);
                            }
                        }
                }
                }
                catch (Exception ex)
                {
                    erorrMessages.Add(ex.Message);
                }
                var testIsFinal = _dbContext.RubikaKeywords.Where(w => w.Type == 5 && w.VisitedDate == null && w.Name != null).ToList();
                if (testIsFinal.Any())
                {
                    goto Loop;
                }

            }
            catch (Exception ex)
            {
                var ttt = ex.Message;
                throw;
            }
           

        }
        public async Task<IActionResult> ReadLink()
        {
            var rubikaURL = "https://web.rubika.ir/";
            var options = new ChromeOptions();
            IWebDriver driver = new ChromeDriver(@"E:\Tohidi\Projects\Avval\Avval\App_Avval\App_Avval\driver\");
            driver.Navigate().GoToUrl(rubikaURL);
            IWebElement input_el = driver.FindElement(By.Name("phone_number"));
            input_el.SendKeys("9361798086");
            IWebElement button_el = driver.FindElement(By.TagName("button"));
            button_el.Click();

            //phone_code
            //Thread.Sleep(15000);
            var code = System.IO.File.ReadAllText("code.txt");
            IWebElement code_el = driver.FindElement(By.Name("phone_code"));
            code_el.SendKeys(code);
            //WebDriverWait _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            //_webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(webDriver.FindElement(By.Name("phone_code")), code));
            //Thread.Sleep(15000);
            //driver.Navigate().Refresh();
            var htmlnew = driver.PageSource;
            List<string> erorrMessages = new List<string>();


            try
            {
                Thread.Sleep(1000);
                IList<IWebElement> messages = driver.FindElement(By.Id("folders-container")).FindElements(By.TagName("li"));
                int index = 0;
                foreach (var message in messages)
                {
                    try
                    {
                        // Search
                        var contactName = message.FindElement(By.ClassName("peer-title")).Text;

                        if (contactName == "طاها")
                        {
                            messages[index].Click();
                            break;
                        }
                        //var mId = message.GetAttribute("data-msg-id");
                        //var msg = message.Text;
                        //var date = message.FindElement(By.TagName("span")).Text;
                        Thread.Sleep(1000);
                        //driver.FindElement(By.ClassName("chat-info-container")).Click();

                        index++;
                    }
                    catch (Exception ex)
                    {
                        erorrMessages.Add(ex.Message);
                        index++;
                    }
                }

                bool hasUrl = true;
                while (hasUrl)
                {
                    foreach (var url in _dbContext.RubikaLinks.Where(w => w.VisitedDate == null).ToList())
                    {
                        try
                        {

                            url.VisitedDate = DateTime.Now;
                            _dbContext.RubikaLinks.Update(url);
                            _dbContext.SaveChanges();

                            if (!messages.Any())
                                messages = driver.FindElement(By.Id("folders-container")).FindElements(By.TagName("li"));

                            messages[index].Click();

                            Thread.Sleep(1000);
                            //IWebElement input = driver.FindElement(By.TagName("")).FindElement(By.TagName("input"));

                            driver.FindElement(By.ClassName("composer_rich_textarea")).Click();
                            driver.FindElement(By.ClassName("composer_rich_textarea")).Clear();
                            driver.FindElement(By.ClassName("composer_rich_textarea")).SendKeys(url.Link);
                            driver.FindElement(By.XPath("//button[@class='btn-icon rbico-none btn-circle z-depth-1 btn-send animated-button-icon rp send']")).Click();

                            Thread.Sleep(1000);



                            var anchors = driver.FindElement(By.ClassName("bubbles-inner")).FindElements(By.TagName("a"));
                            //var first = anchors.FirstOrDefault().Text;
                            var textlink = anchors.LastOrDefault().Text;
                            anchors.LastOrDefault().Click();
                            //var isvalid = await GetLinksClickAsync(anchors, url.Link);
                            //if(isvalid)
                            {
                                if (url.Link.Contains("join"))
                                {
                                    Thread.Sleep(1000);
                                    try
                                    {

                                        driver.FindElement(By.XPath("//button[@class='btn primary rp']")).Click();
                                    }
                                    catch (Exception ex)
                                    {


                                    }

                                }
                                else
                                {

                                }
                                Thread.Sleep(1000);
                                driver.FindElement(By.ClassName("chat-info-container")).Click();
                                Thread.Sleep(1000);
                                var resultConvert = ConvertRubikaHtmlToModel(driver,"");
                            }


                            //Thread.Sleep(1000);

                        }
                        catch (Exception ex)
                        {
                            erorrMessages.Add(ex.Message);
                        }
                    }
                    if (_dbContext.RubikaLinks.Where(w => w.VisitedDate == null).Any())
                        hasUrl = true;
                    else
                        hasUrl = false;
                }
            }
            catch (Exception ex)
            {
                erorrMessages.Add(ex.Message);
            }

            return View();
        }

        public void fnRemoveChannel(IWebDriver driver)
        {
            try
            {

                for (int j = 1; j < 1000; j++)
                {
                    driver.Navigate().Refresh();
                    Thread.Sleep(2000);
                    var li = driver.FindElements(By.TagName("li"));
                    for (int i = 3; i < li.Count(); i++)
                    {
                        try
                        {

                            Actions actions = new Actions(driver);
                            li[i].Click();
                            Thread.Sleep(1000);
                            driver.FindElement(By.XPath("//div[contains(@class, 'btn-icon rbico-more btn-menu-toggle rp')]")).Click();
                            Thread.Sleep(1000);
                            driver.FindElement(By.XPath("//div[contains(@class, 'btn-menu-item rbico-delete danger rp')]")).Click();
                            Thread.Sleep(1000);

                            var bottun = driver.FindElement(By.XPath("//button[contains(@class, 'btn danger rp')]"));
                            bottun.Click();
                            Thread.Sleep(1000);
                        }
                        catch (Exception ex)
                        {

                            var tt = ex.Message;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                var tt = ex.Message;
            }
        }

        public async Task<IActionResult> RemoveChannel()
        {
            var rubikaURL = "https://web.rubika.ir/";
            //var mobile = "9361798086";
            var mobile = "9214560765";
            ChromeOptions options = new ChromeOptions();
            options = loadcoockie(mobile);
            IWebDriver driver = new ChromeDriver(@"E:\Tohidi\Projects\Avval\Avval\App_Avval\App_Avval\driver\driver123\", options);
            driver.Navigate().GoToUrl(rubikaURL);

            IWebElement input_el = driver.FindElement(By.Name("phone_number"));
            //input_el.SendKeys("9361798086");
            input_el.SendKeys("9214560765");
            IWebElement button_el = driver.FindElement(By.TagName("button"));
            button_el.Click();
            //phone_code
            //Thread.Sleep(15000);
            var code = System.IO.File.ReadAllText("code.txt");
            IWebElement code_el = driver.FindElement(By.Name("phone_code"));
            code_el.SendKeys(code);
            //WebDriverWait _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            //_webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(webDriver.FindElement(By.Name("phone_code")), code));
            //Thread.Sleep(15000);
            //driver.Navigate().Refresh();
            var htmlnew = driver.PageSource;

            try
            {

                for (int j = 1; j < 50; j++)
                {
                    driver.Navigate().Refresh();
                    Thread.Sleep(2000);
                    var li = driver.FindElements(By.TagName("li"));
                    for (int i = 2; i < li.Count(); i++)
                    {
                        try
                        {

                            Actions actions = new Actions(driver);
                            li[i].Click();
                            Thread.Sleep(1000);
                            driver.FindElement(By.XPath("//div[contains(@class, 'btn-icon rbico-more btn-menu-toggle rp')]")).Click();
                            Thread.Sleep(1000);
                            driver.FindElement(By.XPath("//div[contains(@class, 'btn-menu-item rbico-delete danger rp')]")).Click();
                            Thread.Sleep(1000);

                            var bottun = driver.FindElement(By.XPath("//button[contains(@class, 'btn danger rp')]"));
                            bottun.Click();
                            Thread.Sleep(1000);
                        }
                        catch (Exception ex)
                        {

                            var tt = ex.Message;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                var tt = ex.Message;
            }
            return View();
        }

        public async Task<IActionResult> Index()
        {



            return View();
        }
        public bool ConvertRubikaHtmlToModel(IWebDriver driver,string keyword)
        {
            try
            {

                string username = "";
                var result = new RubikaModel();
                try
                {

                    driver.FindElement(By.ClassName("chat-info-container")).Click();
                    Thread.Sleep(1000);
                    username = driver.FindElement(By.XPath("//div[contains(@class, 'row-title rbico rbico-username')]")).Text;
                }
                catch (Exception)
                {


                }
                var ddd = driver.FindElement(By.TagName("tab-conversation")).Text;
                string[] read = ddd.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //var ddd22 = driver.FindElement(By.TagName("tab-conversation")).GetAttribute("class");
                IWebElement ddd22 = driver.FindElement(By.ClassName("bubbles-inner"));
                string channelId = ddd22.GetAttribute("data-chat-id");
                var type = driver.FindElement(By.XPath("//div[contains(@class, 'transition slide-fade')]")).Text;

                result.ChannelId = channelId;
                if (read.Any())
                    result.Name = read[0];
                int member = 0;
                if (read.Count() > 1)
                {
                    int.TryParse(read[1].Replace(" مشترک", ""), out member);
                    result.MemberCount = member;
                }
                if (read.Count() > 2)
                {
                    if (read[2].Contains("مشترک"))
                    {
                        int.TryParse(read[1].Replace(" مشترک", ""), out member);
                        result.MemberCount = member;
                    }
                    else
                        result.Date = read[2];
                }
                result.UserName = username;
                result.Type = type;

                //result.Description = driver.FindElement(By.ClassName("row-title rbico rbico-info")).Text;
                var channel = _dbContext.RubikaModels.FirstOrDefault(f => f.ChannelId.Contains(channelId));
                if (channel == null) // Insert
                {
                    result.Description = keyword;
                    result.TypeSotware = 1;
                    _dbContext.RubikaModels.Add(result);
                    _dbContext.SaveChanges();
                    return true;
                }
                else  // Update
                {
                    if(result.MemberCount != 0)
                        channel.MemberCount = result.MemberCount;
                    channel.Date = result.Date;
                    channel.Name = result.Name;
                    channel.VisitedDate = DateTime.Now;
                    channel.Description = result.Description;
                    channel.Description_Links = result.Description_Links;
                    channel.UserName = username;
                    channel.Type = type;
                    channel.TypeSotware = 1;

                    _dbContext.Update(channel);
                    _dbContext.SaveChanges();
                    return false;
                }

                try
                {

                    var anchors = driver.FindElements(By.TagName("a"));
                    var links = GetLinksSave(anchors, channelId);

                }
                catch (Exception)
                {


                }

                try
                {
                    if (1 == 0)
                    {
                        IList<IWebElement> messages = driver.FindElements(By.ClassName("bubbles-date-group"));
                        var posts = new List<RubikaPost>();
                        foreach (var message in messages)
                        {
                            var post = new RubikaPost();
                            post.ChannelId = channelId;
                            post.MessageId = message.GetAttribute("data-msg-id");
                            post.Description = message.Text;
                            post.Date = message.FindElement(By.TagName("span")).Text;
                            //var count =message.FindElement(By.ClassName("time rbico"));
                            post.HTML = message.ToString();

                            posts.Add(post);
                        }
                        _dbContext.RubikaPosts.AddRange(posts);
                        _dbContext.SaveChanges();
                    }
                }
                catch (Exception)
                {

                }
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<string> GetLinksSave(IReadOnlyCollection<IWebElement> anchors, string channelId)
        {
            var result = new List<string>();
            var i = anchors.Count();
            foreach (var anchor in anchors)
            {
                var text = anchor.Text;

                if (!string.IsNullOrEmpty(text))
                    if (text.StartsWith("@"))
                    {

                        //_dbContext.Add(new RubikaLink()
                        //{
                        //    ChannelId = channelId,
                        //    Link = text,
                        //    Type = 2
                        //});
                        //_dbContext.SaveChanges();
                    }

                if (anchor.GetAttribute("href") != null)
                {
                    if (!string.IsNullOrEmpty(anchor.GetAttribute("href")))
                        if (anchor.GetAttribute("href").Contains("https://eitaa.com/"))
                        {
                            //anchor.Click();
                            //break;
                            var link = anchor.GetAttribute("href").Trim();

                            if (_dbContext.RubikaLinks.FirstOrDefault(f => f.Link.Contains(link)) == null)
                            {
                                result.Add(link);

                                _dbContext.Add(new RubikaLink()
                                {
                                    ChannelId = channelId,
                                    Link = link,
                                    Type = 1
                                });
                                _dbContext.SaveChanges();
                            }
                        }
                }
            }


            return result;
        }
        public async Task<bool> GetLinksClickAsync(IReadOnlyCollection<IWebElement> anchors, string url)
        {
            var result = false;

            var i = anchors.Count();
            foreach (var anchor in anchors)
            {
                var text = anchor.Text;

                if (!string.IsNullOrEmpty(text))
                    if (text.StartsWith("@" + url))
                    {
                        result = true;
                        anchor.Click();
                        break;
                    }

                if (anchor.GetAttribute("href") != null)
                {
                    if (!string.IsNullOrEmpty(anchor.GetAttribute("href")))
                        if (anchor.GetAttribute("href").Contains(url))
                        {
                            result = true;
                            anchor.Click();
                            break;
                        }
                }
            }


            return result;
        }
        public async Task<IActionResult> ReadFile()
        {

            var rubikaURL = "E:\\Tohidi\\Projects\\Avval\\Avval\\App_Avval\\App_Avval\\mypage.html";
            var options = new ChromeOptions();
            IWebDriver driver = new ChromeDriver(@"E:\Tohidi\Projects\Avval\Avval\App_Avval\App_Avval\driver\");
            driver.Navigate().GoToUrl(rubikaURL);
            var htmlnew = driver.PageSource;
            IList<IWebElement> messages = driver.FindElements(By.ClassName("bubbles-date-group"));

            foreach (var message in messages)
            {
                var mId = message.GetAttribute("data-msg-id");
                var msg = message.Text;
                var date = message.FindElement(By.TagName("span")).Text;
                //var count =message.FindElement(By.ClassName("time rbico"));
            }

            var ddd = driver.FindElement(By.TagName("tab-conversation")).Text;
            string[] read = ddd.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            //var ddd22 = driver.FindElement(By.TagName("tab-conversation")).GetAttribute("class");
            IWebElement ddd22 = driver.FindElement(By.ClassName("bubbles-inner"));
            string id = ddd22.GetAttribute("data-chat-id");
            //chat-info


            return View();
        }
        public async Task<IActionResult> ReadFileChannels()
        {

            var rubikaURL = "E:\\Tohidi\\Projects\\Avval\\Avval\\App_Avval\\App_Avval\\rubika_html\\All_channels.html";
            var options = new ChromeOptions();
            IWebDriver driver = new ChromeDriver(@"E:\Tohidi\Projects\Avval\Avval\App_Avval\App_Avval\driver\driver123\");
            driver.Navigate().GoToUrl(rubikaURL);
            var htmlnew = driver.PageSource;
            IList<IWebElement> messages = driver.FindElements(By.TagName("a"));
            IList<IWebElement> allLink = driver.FindElements(By.XPath("//a[contains(@class, 'add_to_4_rubika')]"));

            var links_insert = new List<RubikaLink>();

            foreach (var link in allLink)
            {
                var sp = link.GetAttribute("href").ToString().Split('/');

                links_insert.Add(new RubikaLink()
                {
                    ChannelId = "Channels.ir",
                    Link = sp.LastOrDefault(),
                    Type = 2
                });

                //var mId = link.GetAttribute("href");
                //var msg = link.Text;
                //var date = link.Text;
                //var count =message.FindElement(By.ClassName("time rbico"));
            }

            _dbContext.AddRange(links_insert);

            return View();
        }
        public async Task<IActionResult> index2()
        {

            var rubikaURL = "https://web.rubika.ir/";
            var options = new ChromeOptions();
            IWebDriver webDriver = new ChromeDriver(@"E:\Tohidi\Projects\Avval\Avval\App_Avval\App_Avval\driver\");
            webDriver.Navigate().GoToUrl(rubikaURL);
            IWebElement input_el = webDriver.FindElement(By.Name("phone_number"));
            input_el.SendKeys("9214560765");
            IWebElement button_el = webDriver.FindElement(By.TagName("button"));
            button_el.Click();

            //phone_code
            Thread.Sleep(15000);
            var code = System.IO.File.ReadAllText("code.txt");
            IWebElement code_el = webDriver.FindElement(By.Name("phone_code"));
            code_el.SendKeys(code);
            //WebDriverWait _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            //_webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(webDriver.FindElement(By.Name("phone_code")), code));
            //Thread.Sleep(15000);
            webDriver.Navigate().Refresh();
            var htmlnew = webDriver.PageSource;

            //var chatlist = webDriver.FindElements(By.XPath("//ul@class='chatlist'"));

            //var homePage = await ConvertRubikaHtmlToModelAsync(webDriver);
            return View();
        }
        public async Task<IActionResult> Temp()
        {

            var rubikaURL = "https://web.rubika.ir/";
            var options = new ChromeOptions();
            IWebDriver driver = new ChromeDriver(@"E:\Tohidi\Projects\Avval\Avval\App_Avval\App_Avval\driver\");
            driver.Navigate().GoToUrl(rubikaURL);
            IWebElement input_el = driver.FindElement(By.Name("phone_number"));
            input_el.SendKeys("9361798086");
            IWebElement button_el = driver.FindElement(By.TagName("button"));
            button_el.Click();

            //phone_code
            //Thread.Sleep(15000);
            var code = System.IO.File.ReadAllText("code.txt");
            IWebElement code_el = driver.FindElement(By.Name("phone_code"));
            code_el.SendKeys(code);
            //WebDriverWait _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            //_webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(webDriver.FindElement(By.Name("phone_code")), code));
            //Thread.Sleep(15000);
            //driver.Navigate().Refresh();
            var htmlnew = driver.PageSource;
            var file_keywords = "E:\\Tohidi\\Projects\\Avval\\Avval\\App_Avval\\App_Avval\\keywords.txt";
            string[] keywords = System.IO.File.ReadAllLines(file_keywords);

            foreach (var keyword in keywords)
            {
                IWebElement input_search = driver.FindElement(By.ClassName("input-search")).FindElement(By.TagName("input"));
                input_search.Clear();
                input_search.SendKeys(keyword);
                input_search.Submit();


                Thread.Sleep(5000);

            }

            return View();
        }
        #region Other

        public async Task<IActionResult> FindKeyword()
        {
            var str = @"
خانواده
رابطه
همسران
همسر
زوج
زوجین
همسرداری
عشق
عاشق
زن و شوهر
شوهر
رابطه
فرزند
فرزندپروری
تربیت فرزند
کودک 
کودکان
لالایی
قصه شب
مادر
پدر
والدین
والد
رابطه
تربیت
تربیتی
نوجوان
ورزش
تربیت بدنی
سلامت جسمی
استقلال
پرسپولیس
فوتبال
والیبال
هنر
هنرمند
هنرمندان
نقاشی
طراحی
خطاطی
موزیک
موسیقی
گرافیک
گرافیست
آهنگ
داستان
شعر 
نویسنده
شاعر
رمان
دانشگاه
روابط عمومی دانشگاه
دانشجو
دانشجویان
پایان نامه
مقاله
سبک زندگی
مهارت
رشد
مهارت زندگی 
زندگی
آرامش
روان
روانشناسی
آرام
شادی
انرژی
مثبت
انرژی مثبت
تفکر مثبت
اندیشه
اندیشه مثبت
مثبت اندیشی";


            //str = str.Replace("(عج)", "").Replace("(ع)", "").Replace("(", "").Replace("|", "").Replace("؛", "").Replace("{", "").Replace("}", "").Replace("“", "").Replace("/", "").Replace("\\", "");
            //str = str.Replace("“", "").Replace("”", "").Replace("،", "").Replace("...", "").Replace(".", "").Replace("!", "").Replace("*", "").Replace("»", "").Replace("«", "").Replace(":", "");
            //var sp = str.Split("-");
            var sp = str.Split(
    new string[] { Environment.NewLine },
    StringSplitOptions.None
);
            foreach (var item in sp)
            {
                var txt = item.Trim();
                if (!string.IsNullOrEmpty(txt))
                    if (_dbContext.RubikaKeywords.FirstOrDefault(f => f.Name == txt) == null)
                    {
                        _dbContext.RubikaKeywords.Add(new RubikaKeywords()
                        {
                            Name = txt,
                            Type = 4,
                        });
                        await _dbContext.SaveChangesAsync();
                    }
            }


            return View();
        }


        #endregion

        #region Eitaa
        public ChromeOptions loadcoockieEitaa(string mobile)
        {
            ChromeOptions chromeOptions = new ChromeOptions();

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
            if (mobile == "9361798086")
                chromeOptions.AddArguments(@"user-data-dir=C:\Users\s.tohidi\AppData\Local\Google\Chrome\User Data\coockietohidiEitaa");
            if (mobile == "9214560765")
                chromeOptions.AddArguments(@"user-data-dir=C:\Users\s.tohidi\AppData\Local\Google\Chrome\User Data\coockiejavadiEitaa");

            //chromeOptions.AddArguments("--user-data-dir=/home/seluser/" + udr.Name);
            //chromeOptions.AddArguments("--profile-directory=Default");
            return chromeOptions;

        }

        public async Task<IActionResult> LoginEitaa()
        {

            var rubikaURL = "https://web.eitaa.com/";
            var options = new ChromeOptions();
            options = loadcoockieEitaa("9214560765");
            //options = loadcoockieEitaa("9361798086");
            IWebDriver webDriver = new ChromeDriver(@"E:\Tohidi\Projects\Avval\Avval\App_Avval\App_Avval\driver\driver123\", options);
            webDriver.Navigate().GoToUrl(rubikaURL);
            IWebElement input_el = webDriver.FindElement(By.XPath("//div[contains(@inputmode, 'decimal')]"));
            input_el.SendKeys("9214560765");
            //input_el.SendKeys("9361798086");
            IWebElement button_el = webDriver.FindElement(By.XPath("//button[contains(@class, 'btn-primary btn-color-primary rp')]"));
            button_el.Click();

            //phone_code
            Thread.Sleep(15000);
            var code = System.IO.File.ReadAllText("code.txt");
            IWebElement code_el = webDriver.FindElement(By.XPath("//input[contains(@class, 'input-field-input')]"));
            code_el.SendKeys(code);
            IWebElement button_code = webDriver.FindElement(By.XPath("//button[contains(@class, 'btn-primary btn-color-primary btn-timer')]"));
            button_code.Click();
            //WebDriverWait _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            //_webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(webDriver.FindElement(By.Name("phone_code")), code));
            //Thread.Sleep(15000);
            webDriver.Navigate().Refresh();
            var htmlnew = webDriver.PageSource;

            //var chatlist = webDriver.FindElements(By.XPath("//ul@class='chatlist'"));

            //var homePage = await ConvertRubikaHtmlToModelAsync(webDriver);
            return View();
        }

        public async Task<IActionResult> ReadLinkEitaa()
        {

            var path = "E:\\Tohidi\\Projects\\Avval\\Avval\\App_Avval\\App_Avval\\eita_link.txt";

            string readContents;
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                readContents = streamReader.ReadToEnd();
            }

            var sp = Common.Utilities.SpilitStrByLine(readContents);
            foreach (var item in sp.ToList())
            {
                if (item.Contains("https://eitaa.com/joinchat"))
                {

                    _dbContext.RubikaLinks.Add(new RubikaLink()
                    {
                        CreatedDate = DateTime.Now,
                        Link = item,
                        Type = 3,
                    });
                    _dbContext.SaveChanges();
                }
            }

            return View();
        }

        public async Task<IActionResult> ReadChannelEitaa()
        {
            var rubikaURL = "https://web.eitaa.com/";
            var options = new ChromeOptions();
            options = loadcoockieEitaa("9214560765");
            IWebDriver driver = new ChromeDriver(@"E:\Tohidi\Projects\Avval\Avval\App_Avval\App_Avval\driver\driver123\", options);
            driver.Navigate().GoToUrl(rubikaURL);

            var links = _dbContext.RubikaLinks.Where(w => w.Id < 53720 && w.Link.StartsWith("https://eitaa.com/joinchat")).ToList();
            var menu_count = 1;
            foreach (var link in links)
            {
                try
                {

                    var menus = driver.FindElement(By.ClassName("chatlist")).FindElements(By.TagName("li"));
                    if (menu_count == 1)
                        foreach (var menu in menus)
                        {
                            if (menu.Text.Contains("ایتا"))
                            {
                                menu.Click();
                                Thread.Sleep(1000);
                                break;
                            }
                        }
                    menu_count++;

                    var input = driver.FindElement(By.XPath("//div[contains(@class, 'input-message-input scrollable scrollable-y i18n no-scrollbar')]"));
                    input.Clear();
                    input.SendKeys(link.Link);
                    IWebElement button_code = driver.FindElement(By.XPath("//button[contains(@class, 'btn-icon tgico-none btn-circle z-depth-1 btn-send animated-button-icon rp send')]"));
                    button_code.Click();
                    int i = 1, j = 1, k = 1;
                    var all_group_message = driver.FindElements(By.XPath("//div[contains(@class, 'bubbles-date-group')]")).LastOrDefault();
                    //foreach (var item in all_group_message)
                    {
                        //if (all_group_message.Count() == i)
                        {
                            j = 1;
                            var bubble = all_group_message.FindElements(By.XPath("//div[contains(@class, 'bubble')]")).LastOrDefault();
                            //foreach (var item1 in bubble)
                            {

                                var txt = bubble.Text;
                                //if (bubble.Count() == j)
                                if (bubble.Text.StartsWith("https://eitaa.com/joinchat"))
                                {
                                    var a = bubble.FindElement(By.TagName("a"));
                                    a.Click();
                                    Thread.Sleep(1000);

                                    // read Group
                                    IWebElement elm = driver.FindElement(By.XPath("//div[contains(@class, 'popup-container z-depth-1')]"));
                                    var resultReadGroup = await ReadGroupEitaa(elm, link.Link);


                                    //break;
                                }
                                j++;
                            }
                        }
                        i++;
                    }


                }
                catch (Exception)
                {


                }
            }
            return View();
        }

        public async Task<bool> ReadGroupEitaa(IWebElement elm, string link)
        {
            try
            {
                if (elm != null)
                {
                    var name = elm.FindElement(By.ClassName("chat-title")).Text;
                    if (elm.FindElement(By.XPath("//span[contains(@class, 'i18n chat-participants-count')]")).Text.Contains("عضو"))
                    {
                        var memberCountStrng = elm.FindElement(By.XPath("//span[contains(@class, 'i18n chat-participants-count')]")).Text.Trim().Replace(" ", "").Replace("عضو", "").Replace("⁨", "").Replace("⁩مشترک", "");
                        int memberCount = 0;
                        int.TryParse(memberCountStrng, out memberCount);
                        string memberString = memberCount.ToString();
                        if (memberCount == 0)
                            memberString = memberCountStrng;
                        var group = await _dbContext.RubikaGroups.FirstOrDefaultAsync(f => f.Link.Contains(link));

                        if (group == null)
                        {
                            await _dbContext.RubikaGroups.AddAsync(new RubikaGroup()
                            {
                                Name = name,
                                MemberCount = memberString,
                                TypeSotware = 2,
                                Link = link,
                            });
                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {

                        }

                    }
                    var button_cancel = elm.FindElements(By.TagName("button")).LastOrDefault();
                    button_cancel.Click();

                    Thread.Sleep(1000);
                    }
                
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public void ReadKeywordForIdEitaa(int idMin, int idMax)
        {
            var rubikaURL = "https://web.eitaa.com/";
            //var mobile = "9361798086";
            var mobile = "9214560765";
            ChromeOptions options = new ChromeOptions();
            options = loadcoockieEitaa(mobile);
            try
            {
                IWebDriver driver = new ChromeDriver(@"E:\Tohidi\Projects\Avval\Avval\App_Avval\App_Avval\driver\driver123\", options);

                driver.Navigate().GoToUrl(rubikaURL);

                //IWebElement input_el = driver.FindElement(By.Name("phone_number"));
                //input_el.SendKeys(mobile);
                ////input_el.SendKeys(mobile);
                //IWebElement button_el = driver.FindElement(By.TagName("button"));
                //button_el.Click();
                ////phone_code
                ////Thread.Sleep(15000);
                //var code = System.IO.File.ReadAllText("code.txt");
                //IWebElement code_el = driver.FindElement(By.Name("phone_code"));
                //code_el.SendKeys(code);
                //WebDriverWait _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
                //_webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(webDriver.FindElement(By.Name("phone_code")), code));
                //Thread.Sleep(15000);
                //driver.Navigate().Refresh();
                var htmlnew = driver.PageSource;
                //ReadOnlyCollection<OpenQA.Selenium.Cookie> cc = driver.Manage().Cookies.AllCookies;
                //foreach (var item in cc)
                //{
                //    driver.Manage().Cookies.AddCookie(item);
                //}
                //driver.Manage().Window.Minimize();  
                //driver.ExecuteJavaScript("return document.hidden;");

                //var file_keywords = "E:\\Tohidi\\Projects\\Avval\\Avval\\App_Avval\\App_Avval\\keywords.txt"; 
                //var file_keywords = "E:\\Tohidi\\Projects\\Avval\\Avval\\App_Avval\\App_Avval\\keywordsAll.csv"; 
                //string[] keywords = System.IO.File.ReadAllLines(file_keywords);
                //var keywords = _dbContext.RubikaKeywords.Where(w => w.VisitedDate == null && w.Name.Length > 2 && w.Id <= idMax && w.Id >= idMin).ToList();
                var keywords = _dbContext.RubikaKeywords.Where(w => w.Name.Length > 2 && w.Name != null).ToList();
                int countchannel = 0;
                List<string> erorrMessages = new List<string>();
                try
                {

                    foreach (var txt in keywords)
                    //for (int m = 0; m < 1000000; m++)
                    {
                        driver.Navigate().Refresh();
                        //var key1 = keywords.OrderBy(w => Guid.NewGuid()).FirstOrDefault();
                        //var key2 = keywords.OrderBy(w => Guid.NewGuid()).FirstOrDefault();
                        //var keyword = key1.Name + " " + key2.Name;
                        var keyword = txt.Name;
                        int count = 0;
                        try
                        {

                            if (countchannel > 100)
                            {
                                countchannel = 0;
                                //fnRemoveChannel(driver);
                            }

                            try
                            {

                                // active 
                                //var li = driver.FindElements(By.TagName("li"));
                                //for (int n = 1; n < li.Count(); n++)
                                //{
                                //    try
                                //    {

                                //        Actions actions = new Actions(driver);
                                //        li[n].Click();
                                //        Thread.Sleep(1000);
                                //        //driver.FindElement(By.ClassName("chat-info-container")).Click();
                                //        break;
                                //    }
                                //    catch (Exception ex)
                                //    {

                                //        var tt = ex.Message;
                                //    }
                                //}

                            }
                            catch (Exception)
                            {


                            }
                            // Search
                            IWebElement searchClick = driver.FindElement(By.XPath("//div[contains(@id, 'main-search')]"));
                            searchClick.Click();
                            Thread.Sleep(1000);

                            //تب سراسری

                            var tabDiv = driver.FindElement(By.XPath("//div[contains(@class, 'scrollable scrollable-x search-super-nav-scrollable')]"));
                            var tabs = tabDiv.FindElements(By.XPath("//div[contains(@class, 'menu-horizontal-div-item rp')]"));
                            int i = 0;
                            foreach (var item in tabs)
                            {
                                i++;
                                if (item.Text.Contains("سراسری"))
                                {
                                    item.Click();
                                    break;
                                }
                            }
                            IWebElement input_search = driver.FindElement(By.XPath("//input[contains(@class, 'input-field-input i18n input-search-input')]"));
                            input_search.Clear();
                            input_search.SendKeys(keyword);
                            input_search.Click();
                            Thread.Sleep(2000);

                            i = 0;
                            // Read Menu
                            var menus = driver.FindElement(By.XPath("//div[contains(@class, 'search-group search-group-messages')]")).FindElements(By.TagName("li"));


                            if (menus.Any())
                                foreach (var message in menus)
                                {
                                    try
                                    {

                                        if (message != null)
                                        {
                                            Actions action = new Actions(driver);
                                            bool clicked = true;
                                            try
                                            {
                                                action.MoveToElement(message).Click().Perform();

                                                //driver.FindElement(By.ClassName("chat-info-container")).Click();
                                            }
                                            catch (Exception)
                                            {
                                                clicked = false;
                                            }
                                            if (!clicked)
                                            {

                                            }

                                            //var mId = message.GetAttribute("data-msg-id");
                                            //var msg = message.Text;
                                            //var date = message.FindElement(By.TagName("span")).Text;
                                            //Thread.Sleep(1000);
                                            //driver.FindElement(By.ClassName("chat-info-container")).Click();
                                            Thread.Sleep(1000);
                                            var resultConvert = ConvertRubikaHtmlToModelEitaa(driver);
                                            if (resultConvert)
                                                count++;
                                        }
                                        i++;


                                    }
                                    catch (Exception ex)
                                    {
                                        erorrMessages.Add(ex.Message);
                                        i++;
                                    }
                                }


                            txt.VisitedDateEitaa = DateTime.Now;
                            txt.CountEitaa = count;
                            _dbContext.Update(txt);
                            _dbContext.SaveChanges();

                            countchannel = countchannel + count;

                        }
                        catch (Exception ex)
                        {
                            erorrMessages.Add(ex.Message);
                        }
                    }

                }
                catch (Exception ex)
                {
                    erorrMessages.Add(ex.Message);
                }

            }
            catch (Exception ex)
            {
                var ttt = ex.Message;
                throw;
            }

        }

        public bool ConvertRubikaHtmlToModelEitaa(IWebDriver driver)
        {
            try
            {

                string username = "";
                var result = new RubikaModel();
                try
                {

                    IWebElement context = driver.FindElement(By.XPath("//div[contains(@class, 'tabs-tab main-column')]"));
                    context.FindElement(By.TagName("avatar-element")).Click();
                    //Thread.Sleep(2000);
                    result.UserName = driver.FindElement(By.XPath("//div[contains(@class, 'row-title tgico tgico-username')]")).Text;
                    result.Name = context.FindElement(By.ClassName("peer-title")).Text;
                    result.ChannelId = context.FindElement(By.ClassName("peer-title")).GetAttribute("data-peer-id");
                    string member = context.FindElement(By.ClassName("i18n")).Text.Trim().Replace(" ", "").Replace("⁨", "").Replace("⁩مشترک", "");
                    result.MemberCount = Convert.ToInt32(member);
                }
                catch (Exception)
                {


                }
                if (!string.IsNullOrEmpty(result.ChannelId))
                {
                    //result.Description = driver.FindElement(By.ClassName("row-title rbico rbico-info")).Text;
                    var channel = _dbContext.RubikaModels.FirstOrDefault(f => f.ChannelId.Contains(result.ChannelId) && f.TypeSotware == 2);
                    if (channel == null) // Insert
                    {
                        result.Date = "";
                        result.CreatedDate = DateTime.Now;
                        result.TypeSotware = 2;
                        _dbContext.RubikaModels.Add(result);
                        _dbContext.SaveChanges();
                    }
                    else  // Update
                    {
                        channel.TypeSotware = 2;
                        channel.MemberCount = result.MemberCount;
                        channel.Date = result.Date;
                        channel.Name = result.Name;
                        channel.VisitedDate = DateTime.Now;
                        channel.Description = result.Description;
                        channel.Description_Links = result.Description_Links;
                        channel.UserName = username;

                        _dbContext.Update(channel);
                        _dbContext.SaveChanges();
                    }

                    try
                    {
                        var bubble = driver.FindElement(By.ClassName("bubbles"));
                        var anchors = bubble.FindElements(By.TagName("a"));
                        var links = GetLinksSave(anchors, result.ChannelId);

                    }
                    catch (Exception)
                    {


                    }

                    try
                    {

                        //IList<IWebElement> messages = driver.FindElements(By.ClassName("bubbles-date-group"));
                        //var posts = new List<RubikaPost>();
                        //foreach (var message in messages)
                        //{
                        //    var post = new RubikaPost();
                        //    post.ChannelId = channelId;
                        //    post.MessageId = message.GetAttribute("data-msg-id");
                        //    post.Description = message.Text;
                        //    post.Date = message.FindElement(By.TagName("span")).Text;
                        //    //var count =message.FindElement(By.ClassName("time rbico"));
                        //    post.HTML = message.ToString();

                        //    posts.Add(post);
                        //}
                        //_dbContext.RubikaPosts.AddRange(posts);
                        //_dbContext.SaveChanges();

                    }
                    catch (Exception)
                    {

                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<IActionResult> ReadKeywordEitaa()
        {


            ReadKeywordForIdEitaa(0, 2400);

            return View();
        }

        #endregion
    }
}