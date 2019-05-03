using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Xamarin.Forms;

namespace Sem_IMTA_Restaurace.Models
{
    public class Restaurant
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }
        public Location Location { get; private set; }
        public string User_rating { get; private set; }
        public string Image_url { get; private set; }

        public Restaurant(string id, string name, string url, Location location, string user_rating, string image_url)
        {
            Id = id;
            Name = name;
            Url = url;
            Location = location;
            User_rating = user_rating;
            Image_url = image_url;
        }
    }
}
