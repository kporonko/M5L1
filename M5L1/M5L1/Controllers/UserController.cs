using M5L1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5L1.Controllers
{
    public class UserController
    {
        public static async Task ListUsersAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://reqres.in/");

            HttpResponseMessage result = await client.GetAsync("api/users?page=2");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("OK");
                string content = await result.Content.ReadAsStringAsync();
                Console.WriteLine(content + "\n");
                UserPage? page = JsonConvert.DeserializeObject<UserPage>(content);

                if (page is not null)
                {
                    Console.WriteLine("Page: " + page.Page);
                    Console.WriteLine("PerPage: " + page.PerPage);
                    Console.WriteLine("Total: " + page.Total);
                    Console.WriteLine("TotalPages: " + page.TotalPages);
                    Console.WriteLine("Data: \n");
                    foreach (var user in page.Data)
                    {
                        Console.WriteLine($"\t{user.Id}");
                        Console.WriteLine($"\t{user.Email}");
                        Console.WriteLine($"\t{user.FirstName}");
                        Console.WriteLine($"\t{user.LastName}");
                        Console.WriteLine($"\t{user.Avatar}");
                    }

                    Console.WriteLine("\n");
                }
            }
        }

        public static async Task SingleUserAsync(int number)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in/");

                HttpResponseMessage message = await client.GetAsync($"api/users/{number}");
                Console.WriteLine(message);

                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("OK");

                    string content = await message.Content.ReadAsStringAsync();
                    Console.WriteLine(content + "\n");
                    ReqresSingleUser? user = JsonConvert.DeserializeObject<ReqresSingleUser>(content);

                    if (user is not null)
                    {
                        Console.WriteLine($"\nUser Id: {user.Data.Id}\nUser Email: {user.Data.Email}\nUser First Name: {user.Data.FirstName}\nUser Last Name: {user.Data.LastName}\nUser Avatar: {user.Data.Avatar}\n");
                    }
                }
                else
                {
                    Console.WriteLine("EMPTY");
                }
            }
        }

        public static async Task CreateUser(string name, string job)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in/");
                UserForCreate userForCreate = new UserForCreate { Name = name, Job = job };

                string serializedUser = JsonConvert.SerializeObject(userForCreate);
            }
        }
    }
}
