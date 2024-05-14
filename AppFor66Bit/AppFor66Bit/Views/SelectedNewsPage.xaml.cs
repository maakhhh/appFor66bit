using AppFor66Bit.Models;
using AppFor66Bit.ViewModels;
using AppFor66Bit.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFor66Bit.Views 
{
    public partial class SelectedNewsPage : ContentPage
    {
        SelectedNewsViewModel _viewModel;

        public SelectedNewsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SelectedNewsViewModel(); 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void RemoveItemFromSelected(object sender, EventArgs e)
        {
            var swipeItem = (SwipeItem)sender;
            var item = (News)swipeItem.BindingContext;
            _viewModel.RemoveItemFromSelectedNews(item);
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
    }
}