using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HotelWebService;

namespace HotelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string serverUrl = "http://localhost:50330";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Console.WriteLine("heh");
                    var response = client.GetAsync("api/Hotels").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Guestlist = response.Content.ReadAsAsync<IEnumerable<Guest>>().Result;
                        foreach (var guest in Guestlist)
                            Console.WriteLine(guest);
                    }
                    Console.WriteLine("ee");
                }
                catch (Exception)
                {

                    throw;
                }

                Console.ReadLine();
            }
        }
    }
}
