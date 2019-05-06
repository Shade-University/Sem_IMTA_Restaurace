using Newtonsoft.Json.Linq;
using Sem_IMTA_Restaurace.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Sem_IMTA_Restaurace.Services
{
    public class RestaurantApi : IRestaurantApi
    {
        private const string API_KEY = "981bcaa15032666ff422b1b3dbeaafe3";

        private readonly WebClient client = new WebClient();
        public RestaurantApi()
        {
            client.Headers.Add($"user-key: {API_KEY}");
            client.Headers.Add("Accept: application/json");
        }

        public IEnumerable<Restaurant> GetRestaurantsByLocation(string latitude, string longitude)
        {
            return GetRestaurants($"https://developers.zomato.com/api/v2.1/search?q=czech&lat={latitude}&lon={longitude}&sort=real_distance");
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
                (double)r["restaurant"]["location"]["latitude"],
                (double)r["restaurant"]["location"]["longitude"]
                ),
            new Rating(
                (double)r["restaurant"]["user_rating"]["aggregate_rating"],
                (string)r["restaurant"]["user_rating"]["rating_text"],
                (int)r["restaurant"]["user_rating"]["votes"]
                ),
            (string)r["restaurant"]["thumb"],
            (string)r["restaurant"]["featured_image"],
            (string)r["restaurant"]["menu_url"]
            )
        ).ToList();
        }
    }
}
