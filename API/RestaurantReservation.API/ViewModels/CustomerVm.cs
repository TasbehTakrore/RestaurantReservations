﻿namespace RestaurantReservation.API.Controllers
{
    public class CustomerVM
    {
        public int CustomerId { get; init; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}