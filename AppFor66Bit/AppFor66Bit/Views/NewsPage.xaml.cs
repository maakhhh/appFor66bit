using AppFor66Bit.Models;
using AppFor66Bit.ViewModels;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFor66Bit.Views
{
    public partial class NewsPage : ContentPage
    {

        NewsViewModel _viewModel;

        public NewsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new NewsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }


        private void AddItemToSelected(object sender, EventArgs e)
        {
            var swipeItem = (SwipeItem)sender;
            var item = (News)swipeItem.BindingContext;
            _viewModel.AddItemToSelectedNews(item);
            _viewModel.UpdateNews();
        }

        private void AddItemToHiddenNews(object sender, EventArgs e)
        {
            var swipeItem = (SwipeItem)sender;
            var item = (News)swipeItem.BindingContext;
            _viewModel.AddItemToHiddenNews(item);
            _viewModel.UpdateNews();
        }

        private void ChangeContentVisible(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = button.CommandParameter as News;
            item.IsContentOpen = !item.IsContentOpen;
            button.Text = item.IsContentOpen ? "Скрыть" : "Показать еще...";
            _viewModel.UpdateNews();
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            Debug.WriteLine("Поскролили до ");
            Debug.WriteLine(e.ScrollY);
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            Debug.WriteLine("1242341234");
            _viewModel.LoadItemsCommand.Execute(false);
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            Debug.WriteLine("1242341234");
            _viewModel.LoadItemsCommand.Execute(false);
        }

        private void ItemsListView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.VerticalOffset <= 0)
            {
                var a = (CollectionView)sender;
                var b = BrowseItemsPage;
            }
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {
            Debug.WriteLine("1242341234");
            _viewModel.LoadItemsCommand.Execute(false);
        }
    }
}