﻿using AutoMapper;
using RestaurantReservation.API.Controllers;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.Application.DTOs;

namespace RestaurantReservation.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerVM, CustomerDTO>()
                .ReverseMap();
            CreateMap<CustomerRequestDTO, CustomerDTO>()
                .ReverseMap();
        }
    }
}
