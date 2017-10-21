using System.Collections.Generic;

namespace PFoursquare.API.Model
{
    public class MCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string ShortName { get; set; }
        public MCategoryIcon Icon { get; set; }
        public List<MCategory> Categories { get; set; }
    }

    public class MCategoryIcon
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }
}
