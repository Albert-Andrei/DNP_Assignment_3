using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment_3Client.Model;

namespace Assignment_3Client.Data
{
    public class AdultServiceA : IAdultServiceA
    {
        private HttpClient client;

        public AdultServiceA()
        {
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdultsAsync() {
            string uri = "https://localhost:5003/Adult";
            HttpResponseMessage response = await client.GetAsync(uri);
            string message = await client.GetStringAsync(uri);
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            Console.Out.WriteLine(response.ToString());
            return result;
        }

        public async Task AddAdultsAsync(Adult adult)
        {
            string todoSerialized = JsonSerializer.Serialize(adult);

            StringContent content = new StringContent(
                todoSerialized,
                Encoding.UTF8,
                "application/json"
            );

            Console.Out.WriteLine(todoSerialized);

            HttpResponseMessage response = await client.PostAsync("https://localhost:5003/Adult", content);
            Console.Out.WriteLine(response.ToString());
        }

        public async Task RemoveAdultsAsync(int personId)
        {
            await client.DeleteAsync($"https://localhost:5003/Adult/{personId}");
        }

        public async Task UpdateAdultsAsync(Adult adult)
        {
            string todoAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync($"https://localhost:5003/Adult/{adult.Id}", content);
        }
    }
}