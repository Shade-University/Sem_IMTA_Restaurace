using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Sem_IMTA_Restaurace.Models;

namespace Sem_IMTA_Restaurace.Services
{
    class RestaurantDataStore : IDataStore<Restaurant>
    {
        private List<Restaurant> restaurants = new List<Restaurant>();
        public void AddItem(Restaurant item)
        {
            restaurants.Add(item);
        }

        public void DeleteItem(string id)
        {
            Restaurant restaurantToRemove = restaurants.Find(restaurant => restaurant.Id.Equals(id));
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
            throw new NotImplementedException();
        }
    }
}
