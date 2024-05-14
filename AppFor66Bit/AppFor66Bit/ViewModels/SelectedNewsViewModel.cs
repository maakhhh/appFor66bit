using AppFor66Bit.Models;
using AppFor66Bit.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFor66Bit.ViewModels
{
    public class SelectedNewsViewModel : BaseViewModel
    {

        public ObservableCollection<News> News { get; }
        public Command LoadItemsCommand { get; }


        public SelectedNewsViewModel()
        {
            Title = "Избранное";
            News = new ObservableCollection<News>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public void RemoveItemFromSelectedNews(News item)
        {
            item.IsFeatured = false;
            DataStore.UpdateItemAsync(item);
        }

        public void AddItemToHiddenNews(News item)
        {
            item.IsHidden = true;
            DataStore.UpdateItemAsync(item);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                News.Clear();
                var news = await DataStore.GetItemsFromDatabaseAsync(true);
                foreach (var currentNew in news)
                {
                    if (currentNew.IsFeatured && !currentNew.IsHidden)
                        News.Add(currentNew);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void UpdateNews()
        {
            var news = DataStore.GetItems();

            if (news == null)
            {
                await ExecuteLoadItemsCommand();
                return;
            }

            News.Clear();
            foreach (var item in news)
            {
                if (!item.IsHidden && item.IsFeatured)
                    News.Add(item);
            }
        }

        public void OnAppearing()
        {
            UpdateNews();
        }

    }
}