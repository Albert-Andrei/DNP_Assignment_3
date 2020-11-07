using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Assigment_No3._0.Model;
using Assigment_No3._0.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Assigment_No3._0.Data
{
    public class AdultService : IAdultService
    {
        private string adultFile = "Json/adults.json";
        private FileContext context;
        private IList<Adult> adults;
        private HttpClient client;

        public AdultService()
        {
            context = new FileContext();
            adults = context.Adults;
            client = new HttpClient();
        }
        
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void WriteToFile()
        {
            string productsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, productsAsJson);
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> result = new List<Adult>(adults);
            return result;
        }

        public async Task<Adult> AddAdultsAsync(Adult person)
        {
            int max = adults.Max(person => person.Id);
            person.Id = (++max); 
            adults.Add(person);
            SaveChanges();
            return person;
        }
        
        public async Task RemoveAdultsAsync(int personId)
        {
            Adult toRemove = adults.First(t => t.Id == personId);
            adults.Remove(toRemove);
            WriteToFile();
            SaveChanges();
        }
        
        public async Task UpdateAdultsAsync(Adult person)
        {
            Adult toUpdate = adults.First(t => t.Id == person.Id);
            toUpdate.Update(person);
            WriteToFile();
        }
    }
}