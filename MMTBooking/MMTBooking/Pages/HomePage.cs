using MMTBooking.Modal;
using OpenQA.Selenium;

namespace MMTBooking.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CloseLoginPopUpIfVisible()
        {
            string closeClass = "commonModal__close";
            var loginClose = driver.FindElements(By.ClassName(closeClass));
            if(loginClose.Count > 0)
            {
                driver.FindElement(By.ClassName(closeClass)).Click();
            }
        }

        public void SelectTripType(string tripType)
        {
            driver.FindElement(By.CssSelector("li[data-cy='"+ tripType + "']")).Click();
        }

        public void SelectFromCity(string fromCity)
        {
            driver.FindElement(By.Id("fromCity")).SendKeys(fromCity);
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("ul[role='listbox'] li")).Click();
        }

        public void SelectToCity(string toCity)
        {
            driver.FindElement(By.Id("toCity")).SendKeys(toCity);
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("ul[role='listbox'] li")).Click();
        }

        public void SelectDate(string date)
        {
            DateTime dt = DateTime.Parse(date);
            var dateElement = driver.FindElements(By.CssSelector("div[aria-label='" + dt.DayOfWeek.ToString().Substring(0, 3) + " " + dt.ToString("MMM") + " " + dt.Day.ToString("D2") + " " + dt.Year.ToString() + "']"));
            while(dateElement.Count == 0)
            {
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("span[aria-label='Next Month']")).Click();
                dateElement = driver.FindElements(By.CssSelector("div[aria-label='" + dt.DayOfWeek.ToString().Substring(0, 3) + " " + dt.ToString("MMM") + " " + dt.Day.ToString("D2") + " " + dt.Year.ToString() + "']"));
            }
            (dateElement.FirstOrDefault()!).Click();
        }

        public void SelectTraveller(int adults, int child)
        {
            var item = driver.FindElement(By.CssSelector("div[data-cy='flightTraveller']"));
            item.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("li[data-cy='adults-"+ adults.ToString() +"']")).Click();
            driver.FindElement(By.CssSelector("li[data-cy='children-"+ child.ToString() +"']")).Click();
            driver.FindElement(By.CssSelector("button[data-cy='travellerApplyBtn']")).Click();
        }

        public void FillDefault(BookingData booking)
        {
            Thread.Sleep(5000);
            CloseLoginPopUpIfVisible();
            SelectTripType(booking.TripType);
            SelectFromCity(booking.From);
            Thread.Sleep(5000);
            SelectToCity(booking.To);
            SelectDate(booking.FromDate);
            SelectDate(booking.ToDate);
        }
    }
}
