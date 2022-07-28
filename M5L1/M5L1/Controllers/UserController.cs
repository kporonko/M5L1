using M5L1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5L1.Controllers
{
    /// <summary>
    /// Queries to users
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Gets the list of users of definite page.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the single user according to id.
        /// </summary>
        /// <param name="number">User`s id.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="name">User-to-create`s name.</param>
        /// <param name="job">User-to-create`s job.</param>
        /// <returns></returns>
        public static async Task CreateUser(string name, string job)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in/");
                UserForCreate userForCreate = new UserForCreate { Name = name, Job = job };

                string serializedUser = JsonConvert.SerializeObject(userForCreate);
                StringContent content = new StringContent(serializedUser, Encoding.Unicode, "application/json");
                HttpResponseMessage message = await client.PostAsync("api/users", content);

                if (message.StatusCode == HttpStatusCode.Created)
                {
                    Console.WriteLine("Created");

                    string res = await message.Content.ReadAsStringAsync();
                    Console.WriteLine(res);

                    UserModel userModel = JsonConvert.DeserializeObject<UserModel>(res);
                    Console.WriteLine(userModel.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the user with put query.
        /// </summary>
        /// <param name="name">User-to-update`s new name.</param>
        /// <param name="job">User-to-update`s new job.</param>
        /// <returns></returns>
        public static async Task UpdateUser(string name, string job)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in/");
                UserForCreate userForCreate = new UserForCreate { Name = name, Job = job };
                string serializedUser = JsonConvert.SerializeObject(userForCreate);
                StringContent content = new StringContent(serializedUser, Encoding.Unicode, "application/json");
                HttpResponseMessage message = await client.PutAsync("api/users/2", content);
                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("Updated");

                    string res = await message.Content.ReadAsStringAsync();
                    Console.WriteLine(res);

                    UserModel userModel = JsonConvert.DeserializeObject<UserModel>(res);
                    Console.WriteLine(userModel.ToString());
                }
            }
        }
         
        /// <summary>
        /// Updates the user with patch query.
        /// </summary>
        /// <param name="name">User-to-update`s new name.</param>
        /// <param name="job">User-to-update`s new job.</param>
        /// <returns></returns>
        public static async Task UpdateUserPatch(string name, string job)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in/");
                UserForCreate userForCreate = new UserForCreate { Name = name, Job = job };
                string serializedUser = JsonConvert.SerializeObject(userForCreate);
                StringContent content = new StringContent(serializedUser, Encoding.Unicode, "application/json");
                HttpResponseMessage message = await client.PatchAsync("api/users/2", content);
                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("Updated");

                    string res = await message.Content.ReadAsStringAsync();
                    Console.WriteLine(res);

                    UserModel userModel = JsonConvert.DeserializeObject<UserModel>(res);
                    Console.WriteLine(userModel.ToString());
                }
            }
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <returns></returns>
        public static async Task DeleteUser()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in/");
                HttpResponseMessage message = await client.DeleteAsync("api/users/2");
                if (message.IsSuccessStatusCode)
                {
                }
            }
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="doWeWantSuccess">If we want to successfullly register with email and password - push 'true'. In the other case - false.</param>
        /// <returns></returns>
        public static async Task RegisterUser(bool doWeWantSuccess)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in/");
                UserRegister user = new UserRegister();
                if (doWeWantSuccess)
                {
                    user = new UserRegister { Email = "eve.holt@reqres.in", Password = "pistol" };
                }
                else
                {
                    user = new UserRegister { Email = "sydney@fife" };
                }
                string serializedUser = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(serializedUser, Encoding.Unicode, "application/json");
                HttpResponseMessage message = await client.PostAsync("api/register", content);
                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("Registered");

                    string res = await message.Content.ReadAsStringAsync();
                    Console.WriteLine(res);

                    UserRegister userRegister = JsonConvert.DeserializeObject<UserRegister>(res);
                    Console.WriteLine($"id: {userRegister.Id}\ntoken: {userRegister.Token}");
                }
                else
                {
                    Console.WriteLine(message.Content.ReadAsStringAsync().Result);
                }
            }
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="doWeWantSuccess">If we want to successfullly login user with email and password - push 'true'. In the other case - false.</param>
        /// <returns></returns>
        public static async Task LoginUser(bool doWeWantSuccess)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in/");
                UserRegister user = new UserRegister();
                if (doWeWantSuccess)
                {
                    user = new UserRegister { Email = "eve.holt@reqres.in", Password = "cityslicka" };
                }
                else
                {
                    user = new UserRegister { Email = "peter@klaven" };
                }
                string serializedUser = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(serializedUser, Encoding.Unicode, "application/json");
                HttpResponseMessage message = await client.PostAsync("api/login", content);
                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("Registered");

                    string res = await message.Content.ReadAsStringAsync();
                    Console.WriteLine(res);

                    UserRegister userLogin = JsonConvert.DeserializeObject<UserRegister>(res);
                    Console.WriteLine($"token: {userLogin.Token}");
                }
                else
                {
                    Console.WriteLine(message.Content.ReadAsStringAsync().Result);
                }
            }
        }

        /// <summary>
        /// Gets the list of users of page with 3sec delay.
        /// </summary>
        /// <returns></returns>
        public static async Task ListUsersDelayAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://reqres.in/");

            HttpResponseMessage result = await client.GetAsync("api/users?delay=3");

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
    }
}
