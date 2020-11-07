using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment_3Client.Model;

namespace Assignment_3Client.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;
        private HttpClient client;
        
        public InMemoryUserService()
        {
            client = new HttpClient();
            users = new[]
            {
                new User
                {
                    Password = "123456", SecurityLevel = 4, UserName = "Troels", UserId = 1
                },
                new User
                {
                    Password = "654321", SecurityLevel = 2, UserName = "Jakob", UserId = 2
                },
                new User
                {
                    Password = "1234567", SecurityLevel = 10, UserName = "Albert", UserId = 0
                }
            }.ToList();
        }
        
        public async Task<User> GetUserAsync(string? username, string? password)
        {
            string uri = "https://localhost:5003/User?";
            
            if (username != null)
            {
                uri += $"&username={username}";
            }

            if (username != null)
            {
                uri += $"&password={password}";
            }

            Console.Out.WriteLine(uri);
            HttpResponseMessage response = await client.GetAsync(uri);
            string message = await client.GetStringAsync(uri);
            User result = JsonSerializer.Deserialize<User>(message);
            return result;
        }
    }
}