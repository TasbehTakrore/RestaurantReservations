﻿using RestaurantReservation.Domain.Enums;

namespace RestaurantReservation.API.DTOs
{
    public class EmployeeRequestDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public int RestaurantId { get; set; }
    }
}
