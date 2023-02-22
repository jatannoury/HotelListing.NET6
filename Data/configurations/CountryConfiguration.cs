using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    Name = "Lebanon",
                    ShortName = "Lb"
                },
                new Country
                {
                    Id = 2,
                    Name = "United States Of America",
                    ShortName = "USA"
                }
                );
        }

        
    }
}
