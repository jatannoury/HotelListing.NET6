using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Country
{
    public class BaseModel
    {
        [Required]
        public string Name{ get; set; }
        public string ShortName{ get; set; }
    }
}
