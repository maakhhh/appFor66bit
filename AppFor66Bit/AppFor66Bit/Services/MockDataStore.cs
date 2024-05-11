using AppFor66Bit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFor66Bit.Services
{
    public class MockDataStore : IDataStore<News>
    {
        readonly List<News> news;

        public MockDataStore()
        {
            news = new List<News>()
            {
                new News { Id=0, Title="Новость номер 1", Content="Описание первой новости большое" },
                new News { Id=1, Title="Новость номер 1", Content="Описание первой новости большое" },
                new News { Id=2, Title="Новость номер 1", Content="Описание первой новости большое" },
                new News { Id=3, Title="Новость номер 1", Content="Описание первой новости большое" },
                new News { Id=4, Title="Новость номер 1", Content="Описание первой новости большое" },
            };
        }

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

        public async Task<IEnumerable<News>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(news);
        }
    }
}