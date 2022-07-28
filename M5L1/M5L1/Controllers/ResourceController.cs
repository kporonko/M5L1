using M5L1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5L1.Controllers
{
    /// <summary>
    /// Queries to resources
    /// </summary>
    public class ResourceController
    {
        /// <summary>
        /// Gets the list of resouces of definite page.
        /// </summary>
        /// <returns></returns>
        public static async Task ResourceListAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in/");
                HttpResponseMessage msg = await client.GetAsync("api/unknown");
                Console.WriteLine(msg);

                if (msg.IsSuccessStatusCode)
                {
                    Console.WriteLine("OK");

                    var content = await msg.Content.ReadAsStringAsync();

                    if (content is not null)
                    {
                        Console.WriteLine(content + "\n");
                    }

                    ResourcePage? page = JsonConvert.DeserializeObject<ResourcePage>(content);
                    if (page is not null)
                    {
                        Console.WriteLine($"Page: {page.Page}\nPerPage: {page.PerPage}\nTotal: {page.Total}\nTotalPages: {page.TotalPages}\n");
                        foreach (var resource in page.Data)
                        {
                            Console.WriteLine(resource.ToString());
                        }
                        Console.WriteLine(page.Support.Url);
                        Console.WriteLine(page.Support.Text);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the single resource according to id.
        /// </summary>
        /// <param name="id">Resource id.</param>
        /// <returns></returns>
        public static async Task SingleResourceAsync(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in/");

                HttpResponseMessage message = await client.GetAsync($"api/unknown/{id}");
                if (message.IsSuccessStatusCode)
                {
                    var content = await message.Content.ReadAsStringAsync();
                    SingleResourcePage? resource = JsonConvert.DeserializeObject<SingleResourcePage>(content);
                    if (resource is not null)
                    {
                        Console.WriteLine(resource.Data.ToString());
                    }
                    Console.WriteLine(resource.Support.Url);
                    Console.WriteLine(resource.Support.Text);
                }
                else
                {
                    Console.WriteLine("EMPTY");
                }
            }
        }
    }
}
