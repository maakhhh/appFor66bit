using AppFor66Bit.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppFor66Bit.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<News> News { get; }
        public Command LoadItemsCommand { get; }

        public AboutViewModel()
        {
            Title = "Новости";
            News = new ObservableCollection<News>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                News.Clear();
                var news = await DataStore.GetItemsAsync(true);
                foreach (var currentNew in news)
                {
                    if (!currentNew.IsFeatured && !currentNew.IsHidden)
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

        public void OnAppearing()
        {
            IsBusy = true;
        }

    }
}