namespace PFoursquare.API.Model
{
    public class MVenue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public MContact Contact { get; set; }
        public MLocation Location { get; set; }

        // TODO: Kalanlar Sonra İhtiyaca Göre Eklenecek
    }
}
