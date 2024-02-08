﻿namespace RestaurantReservation.Domain.Models
{
    public class MenuItemDTO
    {
        public int MenuItemId { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
    }
}