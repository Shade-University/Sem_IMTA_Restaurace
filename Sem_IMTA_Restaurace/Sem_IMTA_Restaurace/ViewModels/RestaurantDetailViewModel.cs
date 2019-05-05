using Sem_IMTA_Restaurace.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sem_IMTA_Restaurace.ViewModels
{
    public class RestaurantDetailViewModel
    {

        public Restaurant Restaurant { get; set; }
        public ICommand ClickCommand { get; set; }
        public RestaurantDetailViewModel(Restaurant restaurant)
        {
            Restaurant = restaurant;
            ClickCommand = new Command<string>((url) =>
            {
                Device.OpenUri(new System.Uri(url));
            });
        }
    }
}
