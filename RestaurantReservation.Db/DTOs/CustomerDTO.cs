﻿namespace RestaurantReservation.Db.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"CustomerId: {CustomerId}, FullName: {FullName}, Email: {Email}, PhoneNumber: {PhoneNumber}";
        }
    }
}
