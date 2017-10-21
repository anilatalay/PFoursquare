using System.Collections.Generic;

namespace PFoursquare.API.Model
{
    public class MLocation
    {
        public string Address { get; set; }
        public string CrossStreet { get; set; }
        public List<MLabeledLatLngs> LabeledLatLngs { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string PostalCode { get; set; }
        public string Cc { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<string> FormattedAddress { get; set; }
    }

    public class MLabeledLatLngs
    {
        public string Label { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
