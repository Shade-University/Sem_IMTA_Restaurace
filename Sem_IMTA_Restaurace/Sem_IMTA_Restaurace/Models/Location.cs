using System;
using System.Collections.Generic;
using System.Text;

namespace Sem_IMTA_Restaurace.Models
{
    public class Location
    {
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        public Location(string address, string city, string latitude, string longitude)
        {
            Address = address;
            City = city;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
