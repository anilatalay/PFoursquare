using System.Collections.Generic;

namespace PFoursquare.API.Model
{
    public class RCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string ShortName { get; set; }
        public RCategoryIcon Icon { get; set; }
        public List<RCategory> Categories { get; set; }
    }

    public class RCategoryIcon
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }
}
