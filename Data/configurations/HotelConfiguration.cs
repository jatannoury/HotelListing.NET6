using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        

        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(

                new Hotel
                {
                    Id = 1,
                    Name = "4 Season",
                    Address = "Beirut",
                    CountryId = 1,
                    Rating = 4
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Grand Hills",
                    Address = "Broumana",
                    CountryId = 2,
                    Rating = 4
                });
        }

        
    }
}
