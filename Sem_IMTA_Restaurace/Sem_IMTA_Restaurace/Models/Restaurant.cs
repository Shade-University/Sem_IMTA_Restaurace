namespace Sem_IMTA_Restaurace.Models
{
    public class Restaurant
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }
        public Location Location { get; private set; }
        public Rating Rating { get; private set; }
        public string Thumb_Image { get; private set; }
        public string Feature_Image { get; private set; }
        public string Menu_Url { get; private set; }

        public Restaurant(string id, string name, string url, Location location, Rating rating, string thumb_Image, string feature_Image, string menu_Url)
        {
            Id = id;
            Name = name;
            Url = url;
            Location = location;
            Rating = rating;
            Thumb_Image = string.IsNullOrEmpty(thumb_Image) ? "https://designermenus.com.au/wp-content/uploads/2016/02/icon-None.png" : thumb_Image;
            Feature_Image = feature_Image;
            Menu_Url = menu_Url;
        }
    }
}
