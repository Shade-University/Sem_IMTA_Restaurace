using Sem_IMTA_Restaurace.Models;
using Sem_IMTA_Restaurace.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Sem_IMTA_Restaurace.ViewModels
{
    class MainPageViewModel
    {
        public ObservableCollection<Restaurant> Restaurants { get; set; }
        public string Title { get; set; }
        public Command LoadItemsCommand { get; set; }

        private IDataStore<Restaurant> store;
        private IRestaurantApi api;
        public MainPageViewModel()
        {
            Title = "Restaurants";
            Restaurants = new ObservableCollection<Restaurant>();
            LoadItemsCommand = new Command(() => RefreshListCommandExecute());
            store = new RestaurantDataStore();
            api = new RestaurantApi();
        }
        public async void FillRestaurants()
        {
            var location = await GetCurrentLocation();
            string lat = location.Latitude.ToString();
            string longi = location.Longitude.ToString();
            //"50.0500", "15.7750")


            foreach (Restaurant restaurant in api.GetRestaurantsByLocation(lat, longi))
            {
                store.AddItem(restaurant);
                Restaurants.Add(restaurant);
            }
        }

        private async Task<Xamarin.Essentials.Location> GetCurrentLocation()
        {
            Xamarin.Essentials.Location location = null;
            try
            {
                location = await Geolocation.GetLocationAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex); //Unable to get location
            }

            return location;

        }

        private void RefreshListCommandExecute()
        {
            try
            {
                Restaurants.Clear();
                var items = store.GetAllItems();
                foreach (var item in items)
                {
                    Restaurants.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

    }
}
