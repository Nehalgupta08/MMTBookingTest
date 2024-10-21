using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MMTBooking.ChromeDriverInitialize
{
    public class Driver
    {
        public static IWebDriver Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
