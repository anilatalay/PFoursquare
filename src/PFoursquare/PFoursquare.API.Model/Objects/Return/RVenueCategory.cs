using System.Collections.Generic;

namespace PFoursquare.API.Model
{
    public class RVenueCategory
    {
        public List<RCategory> Categories { get; set; }
    }

    public class RCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string ShortName { get; set; }
        public List<RCategory> Categories { get; set; }
    }

}
