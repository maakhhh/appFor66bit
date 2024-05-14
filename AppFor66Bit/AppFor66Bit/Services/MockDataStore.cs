using AppFor66Bit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppFor66Bit.Services
{
    public class MockDataStore : IDataStore<News>
    {
        private List<News> news;

        public async Task<bool> UpdateItemAsync(News newToUpdate)
        {
            var oldNew = news.Where((News arg) => arg.Id == newToUpdate.Id).FirstOrDefault();
            news.Remove(oldNew);
            news.Add(newToUpdate);

            return await Task.FromResult(true);
        }

        public async Task<News> GetItemAsync(int id)
        {
            return await Task.FromResult(news.FirstOrDefault(s => s.Id == id));
        }

        public IEnumerable<News> GetItems() => news;

        public async Task<IEnumerable<News>> GetItemsFromDatabaseAsync(bool forceRefresh = false)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://frontappapi.dock7.66bit.ru/api/news/get?count=20&page=1");

            if (true)
            {
                var responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                news = JsonSerializer.Deserialize<List<News>>(json, options);
            }    
            return await Task.FromResult(news);
        }
    }
}