﻿using EntityFrameworkCore.Projectables;
using RestaurantReservation.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Application.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        public EmployeePosition Position { get; set; }

        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        [Projectable]
        public string FullName => FirstName + " " + LastName;
    }
}
