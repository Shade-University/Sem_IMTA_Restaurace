using System.Collections.Generic;
using System.Linq;
using Sem_IMTA_Restaurace.Models;

namespace Sem_IMTA_Restaurace.Services
{
    class RestaurantDataStore : IDataStore<Restaurant>
    {
        private readonly List<Restaurant> restaurants = new List<Restaurant>();
        public void AddItem(Restaurant item)
        {
            restaurants.Add(item);
        }

        public void DeleteItem(string id)
        {
            Restaurant restaurantToRemove = GetItem(id);
            restaurants.Remove(restaurantToRemove);
        }

        public IEnumerable<Restaurant> GetAllItems()
        {
            return restaurants.AsEnumerable();
        }

        public Restaurant GetItem(string id)
        {
            return restaurants.Find(restaurant => restaurant.Id.Equals(id));
        }

        public void RemoveAll()
        {
            restaurants.Clear();
        }

        public void UpdateItem(Restaurant item)
        {
            DeleteItem(item.Id);
            AddItem(item);
        }
    }
}
