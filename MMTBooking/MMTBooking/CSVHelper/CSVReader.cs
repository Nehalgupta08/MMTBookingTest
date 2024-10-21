using CsvHelper;
using MMTBooking.Modal;
using System.Globalization;

namespace MMTBooking.CSVHelper
{
    public static class CSVReader
    {
        public static List<BookingData> GetBookings() {
            string filePath = "./MMTBookingValue.csv";
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<BookingData>().ToList();
            }
        }
    }
}
