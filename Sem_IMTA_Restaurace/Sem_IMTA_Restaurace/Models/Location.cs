namespace Sem_IMTA_Restaurace.Models
{
    public class Location
    {
        public string Address { get; private set; }
        public string City { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Location(string address, string city, double latitude, double longitude)
        {
            Address = address;
            City = city;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
