﻿using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using HotelListing.API.Models.Hotels;

namespace HotelListing.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryModel>().ReverseMap();// to be able to map in both directions
            CreateMap<Country, GetCountryModel>().ReverseMap(); 
            CreateMap<Country, CountryModel>().ReverseMap(); 
            CreateMap<Hotel, HotelModel>().ReverseMap(); 
            CreateMap<Country, UpdateCountryModel>().ReverseMap(); 
        }
    }
}
