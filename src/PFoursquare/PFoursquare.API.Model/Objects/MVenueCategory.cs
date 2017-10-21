using System.Collections.Generic;

namespace PFoursquare.API.Model
{
    public class MVenueCategory
    {
        public Meta Meta { get; set; }
        public Response Response { get; set; }
    }

    public class Response
    {
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string ShortName { get; set; }
        public CategoryIcon Icon { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class CategoryIcon
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class Meta
    {
        public decimal Code { get; set; }
        public string RequestId { get; set; }
    }
}
