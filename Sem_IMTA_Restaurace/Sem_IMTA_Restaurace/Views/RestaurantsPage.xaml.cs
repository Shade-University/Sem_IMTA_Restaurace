using Sem_IMTA_Restaurace.Models;
using Sem_IMTA_Restaurace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sem_IMTA_Restaurace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantsPage : ContentPage
    {
        MainPageViewModel viewModel;
        public RestaurantsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainPageViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Restaurant;
            if (item == null)
                return;

            await Navigation.PushAsync(new RestaurantDetail(new RestaurantDetailViewModel(item)));
        }

        private void Map_Clicked(object sender, EventArgs e)
        {

        }

        private void Refresh_Clicked(object sender, EventArgs e)
        {

        }
    }
}