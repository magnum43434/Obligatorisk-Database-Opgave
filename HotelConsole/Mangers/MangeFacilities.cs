using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HotelWebService;

namespace HotelConsole.Mangers
{
    public class MangeFacilities
    {
        private const string serverUrl = "http://localhost:50330";

        public static void ReadFacilities()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Facilities").Result;
                    var facilities = response.Content.ReadAsAsync<IEnumerable<Facility>>().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        foreach (var item in facilities)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static void CreateFacility(Facility obj)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsJsonAsync("api/Facilities", obj).Result;
                    Console.WriteLine($"\nEn facility er oprettet: " + obj.Name + "\n");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static void DeleteFacility(int id)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.DeleteAsync("api/Facilities/" + id).Result;
                    Console.WriteLine($"Facility med id {id} er slettet");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static void UpdateFacility(int id, Facility facObj)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PutAsJsonAsync("api/Facilities/" + id, facObj).Result;
                    Console.WriteLine($"Facility med id {id} er opdateret");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
