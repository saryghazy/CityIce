using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace IceCity
{
    internal class WeatherService
    {
        public static async Task FetchAndSaveLastMonthWeatherAsync(House house)
        {
            var response = string.Empty;
            DateTime now = DateTime.UtcNow;
            DateTime startMonth = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
            DateTime endMonth = new DateTime(now.Year, now.Month, 1).AddDays(-1);
            var url =
               $"https://archive-api.open-meteo.com/v1/archive?" +
               $"latitude=31.0409&longitude=31.3785" +
               $"&start_date={startMonth:yyyy-MM-dd}" +
               $"&end_date={endMonth:yyyy-MM-dd}" +
               $"&daily=temperature_2m_max,temperature_2m_min";

            try
            {
                using HttpClient client = new HttpClient();
                response = await client.GetStringAsync(url);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"API request failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");

            }
            if (string.IsNullOrWhiteSpace(response))
            {
                Console.WriteLine("No data to process.");
                return;
            }
            using JsonDocument json = JsonDocument.Parse(response);
            var daily = json.RootElement.GetProperty("daily");

            var dates = daily.GetProperty("time").EnumerateArray();
            var maxTemps = daily.GetProperty("temperature_2m_max").EnumerateArray();
            var minTemps = daily.GetProperty("temperature_2m_min").EnumerateArray();

            // 5️⃣ لف على البيانات وتخزين كل يوم
            while (dates.MoveNext() &&
                   maxTemps.MoveNext() &&
                   minTemps.MoveNext())
            {
                DateTime date =
                    DateTime.Parse(dates.Current.GetString());

                // مثال بسيط لمعالجة البيانات
                double averageTemp =
                    (maxTemps.Current.GetDouble() +
                     minTemps.Current.GetDouble()) / 2;

                // إنشاء DailyUsage
                DailyUsage usage =
                    new DailyUsage(date, 0, averageTemp);

                // 6️⃣ حفظ البيانات في الليست
                house.AddDailyUsage(usage);
            }


            
        }
    }
}
