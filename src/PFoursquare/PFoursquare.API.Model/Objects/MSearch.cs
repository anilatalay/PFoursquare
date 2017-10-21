using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PFoursquare.API.Model
{
    public class MSearch
    {
        [DisplayName("Area")]
        public string Area { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; }

        [DisplayName("CategoryId"), Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        public string CategoryId { get; set; }
    }
}
