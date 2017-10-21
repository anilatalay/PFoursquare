using System.Collections.Generic;

namespace PFoursquare.API.Model
{
    public class MBase
    {
        public Meta Meta { get; set; }
        public MResponse Response { get; set; }
    }

    public class Meta
    {
        public decimal Code { get; set; }
        public string RequestId { get; set; }
    }
}
