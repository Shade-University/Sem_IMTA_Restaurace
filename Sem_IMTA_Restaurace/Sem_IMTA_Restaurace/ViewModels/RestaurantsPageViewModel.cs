using Sem_IMTA_Restaurace.Models;
using Sem_IMTA_Restaurace.Services;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Sem_IMTA_Restaurace.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Restaurant> Restaurants { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command ReloadItemsCommand { get; set; }
        
        private string error;
        public string Error_Text
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
                NotifyPropertyChanged(nameof(Error_Text));
            }
        }

        private readonly IDataStore<Restaurant> store;
        private readonly IRestaurantApi api;

        public MainPageViewModel()
        {
            Title = "Restaurants";
            Restaurants = new ObservableCollection<Restaurant>();
            LoadItemsCommand = new Command(() => RefreshListCommandExecute());
            ReloadItemsCommand = new Command(() => FillRestaurants());
            store = new RestaurantDataStore();
            api = new RestaurantApi();
            FillRestaurants();
        }
        private async void FillRestaurants()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var location = await GetCurrentLocation();
                if(location == null)
                {
                    isBusy = false;
                    return;
                }

                string lat = location.Latitude.ToString();
                string longi = location.Longitude.ToString();
                try
                {
                    foreach (Restaurant restaurant in api.GetRestaurantsByLocation(lat, longi))
                    {
                        store.AddItem(restaurant);
                        Restaurants.Add(restaurant);
                    }
                    NotifyPropertyChanged(nameof(Restaurants));
                    Error_Text = string.Empty;
                }
                catch(WebException ex)
                {
                    Console.WriteLine(ex);
                    Error_Text = "Could not connect to internet. Data not updated";
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    Error_Text = "Error parsing json. Data not updated";
                }
                IsBusy = false;
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
                Console.WriteLine(ex);
                Error_Text = "Could not get location. Data not updated";
            }

            return location;

        }

        private void RefreshListCommandExecute()
        {
            if (!IsBusy)
            {
                Task.Run(() =>
                {
                    IsBusy = true;
                    Restaurants.Clear();
                    var items = store.GetAllItems();
                    foreach (var item in items)
                    {
                        Restaurants.Add(item);
                    }
                    NotifyPropertyChanged(nameof(Restaurants));
                    IsBusy = false;
                });
                
            }
        }

    }
}
