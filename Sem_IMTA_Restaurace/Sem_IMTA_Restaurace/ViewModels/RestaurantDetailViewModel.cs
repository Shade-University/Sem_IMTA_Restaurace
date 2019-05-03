using Sem_IMTA_Restaurace.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sem_IMTA_Restaurace.ViewModels
{
    public class RestaurantDetailViewModel
    {

        public Restaurant Restaurant { get; set; }
        public RestaurantDetailViewModel(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }
    }
}
