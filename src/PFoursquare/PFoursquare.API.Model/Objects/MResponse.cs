using System.Collections.Generic;

namespace PFoursquare.API.Model
{
    public class MResponse
    {
        public List<MCategory> Categories { get; set; }
        public MVenue Venue { get; set; }
        public List<MVenue> Venues { get; set; }
    }
}
