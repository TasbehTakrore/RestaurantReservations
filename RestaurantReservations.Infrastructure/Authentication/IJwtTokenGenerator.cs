﻿using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Infrastructure.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}