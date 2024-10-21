using MMTBooking.ChromeDriverInitialize;
using MMTBooking.CSVHelper;
using MMTBooking.Modal;
using MMTBooking.Pages;
using OpenQA.Selenium;

namespace MMTBooking.Tests
{
    [TestClass]
    public class MMTBookingTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        private List<BookingData> bookingData;

        [TestInitialize]
        public void SetUp()
        {
            driver = Driver.Initialize();
            driver.Navigate().GoToUrl("https://www.makemytrip.com/");
            bookingData = CSVReader.GetBookings();
            homePage = new HomePage(driver);
        }

        [TestMethod]
        public void SearchFlights_ValidCities_ShouldShowResults()
        {
            foreach (var booking in bookingData)
            {
                homePage.FillDefault(booking);
                var item = driver.FindElements(By.CssSelector("p#range_error"));
                Assert.IsTrue(item.Count() > 0 ? item.FirstOrDefault()!.Displayed : false);
                homePage.SelectTraveller(booking.Adult, booking.Children);
            }
            driver.FindElement(By.XPath("//a[text()='Search']")).Click();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
