namespace PFoursquare.API.Model
{
    public class RVenue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public RContact Contact { get; set; }
        public RLocation Location { get; set; }

        // TODO: Kalanlar Sonra İhtiyaca Göre Eklenecek
    }
}
