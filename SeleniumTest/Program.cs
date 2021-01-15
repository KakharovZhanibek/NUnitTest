using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test3();

        }
        static void Test1()
        {
            //IWebDriver driver = new OperaDriver();
            //driver.Navigate().GoToUrl("https://www.google.com/");
            //IWebElement elInput = driver.FindElement(By.Name("q"));
            //elInput.SendKeys("step academy");
            //elInput.SendKeys(Keys.Enter);
            //IWebElement aStep = driver.FindElement(By.XPath("/html/body/div[7]/div[2]/div[10]/div[1]/div[2]/div/div[2]/div[2]/div/div/div[2]/div/div[1]/a/h3/span"));
            //aStep.Click();
            //driver.Close();


            //IWebDriver driver1 = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://google.ru");
            //driver.Manage().Window.Maximize();
            //IWebElement elInput1 = driver.FindElement(By.Name("q"));
            //elInput.SendKeys("step academy");

            IWebDriver driver = new OperaDriver();
            driver.Navigate().GoToUrl("https://mystat.itstep.org/en/auth/login/index");
            IWebElement elUsernameInput = driver.FindElement(By.XPath("/html/body/mystat/ng-component/ng-component/div/div/div/div/tabset/div/tab[1]/form/div[1]/input"));
            IWebElement elPasswordInput = driver.FindElement(By.XPath("/html/body/mystat/ng-component/ng-component/div/div/div/div/tabset/div/tab[1]/form/div[2]/div[1]/input"));
            IWebElement submitButton = driver.FindElement(By.XPath("/html/body/mystat/ng-component/ng-component/div/div/div/div/tabset/div/tab[1]/form/div[3]/div[1]/button"));

            elUsernameInput.SendKeys("kaha_tr98");
            elPasswordInput.SendKeys("833nj65d");
            submitButton.Click();
            driver.Navigate().GoToUrl("https://mystat.itstep.org/en/main/dashboard/page/index");


            IWebElement redirectToProgressPage = driver.FindElement(By.XPath("/html/body/mystat/ng-component/ng-component/div/div[1]/nav/div/div[2]/ul/li[2]/a/span"));
            redirectToProgressPage.Click();

            IWebElement someInfoElement = driver.FindElement(By.XPath("/html/body/mystat/ng-component/ng-component/div/div[3]/div[2]/ng-component/ng-component/div/div/div[1]/hw-graph/div/div[2]/div[1]/p"));
            string someInfo = someInfoElement.Text;

            someInfoElement = driver.FindElement(By.XPath("/html/body/mystat/ng-component/ng-component/div/div[3]/div[2]/ng-component/ng-component/div/div/div[1]/hw-graph/div/div[2]/div[1]/span[1]"));
            someInfo += " " + someInfoElement.Text;

            Console.WriteLine(someInfo);
        }


        //4. Используя Selenium Web Driver на сайте krisha.kz найти самую дорогую квартиру в Алматы
        static void Test2()
        {
            IWebDriver driver = new OperaDriver();
            driver.Navigate().GoToUrl("https://krisha.kz");

            IWebElement allRegions = driver.FindElement(By.XPath("/html/body/main/section[1]/form/div[1]/div[1]/div[5]/div/a/span[1]"));
            allRegions.Click();
            Thread.Sleep(2000);
            IWebElement almaty = driver.FindElement(By.XPath("/html/body/main/section[1]/form/div[1]/div[1]/div[5]/div/div/div/div[1]/div/select/option[2]"));
            almaty.Click();
            Thread.Sleep(2000);
            IWebElement selectBtn = driver.FindElement(By.XPath("/html/body/main/section[1]/form/div[1]/div[1]/div[5]/div/div/div/div[2]/a"));
            selectBtn.Click();
            Thread.Sleep(2000);
            IWebElement findBtn = driver.FindElement(By.XPath("/html/body/main/section[1]/form/div[2]/div/button"));
            findBtn.Click();
            Thread.Sleep(2000);
            IWebElement expensive = driver.FindElement(By.XPath("/html/body/main/section[3]/div/div[4]/div/div/div[3]/a"));
            expensive.Click();
            Thread.Sleep(2000);
            var cards = driver.FindElements(By.ClassName("a-card"));
            var theMostExpensive = cards.ElementAt(3);
            theMostExpensive.Click();
        }

        //5. Используя Selenium Web Driver на сайте hh.kz найти сколько вакансий "Qa engineer" в Алматы
        static void Test3()
        {
            IWebDriver driver = new OperaDriver();
            driver.Navigate().GoToUrl("https://hh.kz/?customDomain=1");
            IWebElement region = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div/div/div/div[1]/div/button"));
            region.Click();
            Thread.Sleep(2000);
            IWebElement almaty = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div/div[1]/div/div[2]/div[1]/div[6]/div/ul/li[3]/a"));
            almaty.Click();
            Thread.Sleep(2000);
            IWebElement advancedSearch = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/div[3]/div/div/form/div/div[1]/div/span/a/span"));
            advancedSearch.Click();
            Thread.Sleep(2000);
            IWebElement input = driver.FindElement(By.XPath("/html/body/div[6]/div/div/div[2]/div/div[1]/div/form/div[1]/div/div[2]/div[1]/input"));
            input.SendKeys("Qa engineer");
            input.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IWebElement countOfVacanciesEl = driver.FindElement(By.XPath("/html/body/div[6]/div/div/div[2]/div/div[1]/div/h1"));
            Console.WriteLine(countOfVacanciesEl.Text);
        }
    }
}
