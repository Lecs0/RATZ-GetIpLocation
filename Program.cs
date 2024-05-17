using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RATZ_IPLocator
{

    public class Data
    {
        public string ip { get; set; }
        public string timezone { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string postal { get; set; }
        public string loc { get; set; }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "IPLocator";
            Console.Write("Enter IP address: ");
            string IP = Console.ReadLine();
            string URL = $"https://ipinfo.io/{IP}/json";


            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(URL);
                    response.EnsureSuccessStatusCode();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] Http request made");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("---------------------------|");
                    string responseData = await response.Content.ReadAsStringAsync();

                    Data ipInfo = JsonConvert.DeserializeObject<Data>(responseData);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ip: {ipInfo.ip}");
                    Console.WriteLine($"Timezone: {ipInfo.timezone}");
                    Console.WriteLine($"City: {ipInfo.city}");
                    Console.WriteLine($"Region: {ipInfo.region}");
                    Console.WriteLine($"Country: {ipInfo.country}");
                    Console.WriteLine($"Postal: {ipInfo.postal}");
                    Console.WriteLine($"loc: {ipInfo.loc}");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("---------------------------|");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error msg: {ex.Message}");
                Console.WriteLine("Error message logged successfully.");
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Made by Lecs0");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}