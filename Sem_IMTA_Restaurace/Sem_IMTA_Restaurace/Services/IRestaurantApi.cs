﻿using System.Collections.Generic;
using Sem_IMTA_Restaurace.Models;

namespace Sem_IMTA_Restaurace.Services
{
    public interface IRestaurantApi
    {
        IEnumerable<Restaurant> GetRestaurantsByLocation(string latitude, string longitude);
    }
}