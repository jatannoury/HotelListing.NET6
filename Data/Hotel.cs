using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Data
{
    public class Hotel
    {
        public int Id { get; set; } // Primary Key
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; }

        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; } //ForeignKey
        public Country Country { get; set; } //One to One rls


    }
}
