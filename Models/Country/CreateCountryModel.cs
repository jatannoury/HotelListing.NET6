using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Country
{
    // this is practitioning the overposting protection. It is when we want to prevent the user to send harmful data with the request, the user is requested here to send only The name and the shortname of the country on creation.
    public class CreateCountryModel : BaseModel
    {
        public string Id { get; set; }
    }
}
