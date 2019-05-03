using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sem_IMTA_Restaurace.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace Sem_IMTA_Restaurace.Services
{
    public class RestaurantApi : IRestaurantApi
    {
        private const string API_KEY = "981bcaa15032666ff422b1b3dbeaafe3";

        private WebClient client = new WebClient();
        public RestaurantApi()
        {
            client.Headers.Add($"user-key: {API_KEY}");
            client.Headers.Add("Accept: application/json");
        }

        public IEnumerable<Restaurant> GetRestaurantsByCity(string city)
        {
            return GetRestaurants("https://developers.zomato.com/api/v2.1/search?entity_type=city&q=Pardubice&count=20");
            //TODO Nějak jinak
        }

        public IEnumerable<Restaurant> GetRestaurantsByLocation(string latitude, string longitude)
        {
            return GetRestaurants($"https://developers.zomato.com/api/v2.1/search?q=lat={latitude}&lon={longitude}&sort=real_distance");
        }

        private IEnumerable<Restaurant> GetRestaurants(string url)
        {
            string json_data = client.DownloadString(url);
            IList<Restaurant> restaurants = ParseRestaurants(json_data);

            return restaurants;
        }

        private IList<Restaurant> ParseRestaurants(string json)
        {
            JObject root = JObject.Parse(json);
            JArray restaurants = (JArray)root.SelectToken("restaurants");

            return restaurants.Select(r => new Restaurant(
            (string)r["restaurant"]["id"],
            (string)r["restaurant"]["name"],
            (string)r["restaurant"]["url"],
            new Location(
                (string)r["restaurant"]["location"]["address"],
                (string)r["restaurant"]["location"]["city"],
                (string)r["restaurant"]["location"]["latitude"],
                (string)r["restaurant"]["location"]["longitude"]
            ),
            (string)r["restaurant"]["user_rating"]["aggregate_rating"],
            (string)r["restaurant"]["thumb"]
            )
        ).ToList();
        }
    }
}
