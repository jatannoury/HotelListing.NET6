using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Hotels
{
    public abstract class BaseHotelModel
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; } // The double? property designates that the Rating property could be passed as a null value or it is doable to not even pass it
        [Required]
        [Range(0, int.MaxValue)] // validation Rule that states that the range of CountryId should vary between 0 and last value of int before floating occurs (typically  2,147,483,647)
        public int CountryId { get; set; }
    }
}
