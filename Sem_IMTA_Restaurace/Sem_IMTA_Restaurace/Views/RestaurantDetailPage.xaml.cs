using Sem_IMTA_Restaurace.ViewModels;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sem_IMTA_Restaurace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantDetail : ContentPage
    {
        RestaurantDetailViewModel viewModel;
        public RestaurantDetail(RestaurantDetailViewModel model)
        {
            InitializeComponent();
            BindingContext = viewModel = model;
        }

        public void Map_Clicked(object sender, EventArgs e)
        {
            MapLaunchOptions options = new MapLaunchOptions()
            {
                Name = viewModel.Restaurant.Location.Address,
                NavigationMode = NavigationMode.Driving
            };
            Location location = new Location()
            {
                Latitude = viewModel.Restaurant.Location.Latitude,
                Longitude = viewModel.Restaurant.Location.Longitude
            };
            Map.OpenAsync(location, options);
        }
    }
}