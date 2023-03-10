using HotelListing.API.Models.Hotels;

namespace HotelListing.API.Models.Country
{
    public class CountryModel : BaseModel
    {
        public int Id { get; set; }
        public List<HotelModel> Hotels{ get; set; }
    }

}
