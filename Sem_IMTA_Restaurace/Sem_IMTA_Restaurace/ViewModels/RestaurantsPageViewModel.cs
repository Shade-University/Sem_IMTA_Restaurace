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
                try
                {
                    var location = await Geolocation.GetLocationAsync();
                    string lat = location.Latitude.ToString();
                    string longi = location.Longitude.ToString();

                    var restaurants = api.GetRestaurantsByLocation(lat, longi);

                    store.RemoveAll();
                    Restaurants.Clear();
                    foreach (Restaurant restaurant in restaurants)
                    {
                        store.AddItem(restaurant);
                        Restaurants.Add(restaurant);
                    }
                    NotifyPropertyChanged(nameof(Restaurants));
                    Error_Text = string.Empty;
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex);
                    Error_Text = "Could not connect to internet. Data not updated";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Error_Text = "Could not get your gps location. Data not updated";
                }
                IsBusy = false;
            }
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
