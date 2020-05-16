
using ApiClient.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    class Program
    {
        public static async Task GetAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50547/");
                    //add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get/property/all
                    HttpResponseMessage response = await client.GetAsync("Api/Books");
                    if (response.IsSuccessStatusCode)
                    {
                        //read results
                        var stringJson = await response.Content.ReadAsStringAsync();
                        var booking = JsonConvert.DeserializeObject<List<Book>>(stringJson);

                        foreach (var book in booking)
                        {
                            Console.WriteLine("Booking ID is" + book.BookID);
                            Console.WriteLine("Client ID is" + book.ClientID);
                            Console.WriteLine("Date is" + book.DateTime);
                            Console.WriteLine("Counsellor ID is" + book.CounsellorID);

                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        static void Main(string[] args)
        {
            GetAsync().Wait();
            Console.ReadLine();
        }
    }
}
