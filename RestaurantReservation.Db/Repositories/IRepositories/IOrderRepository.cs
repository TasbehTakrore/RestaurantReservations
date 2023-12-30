﻿using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories.IRepositories
{
    public interface IOrderRepository : IEntityRepository<Order>
    {
        Task<IEnumerable<Order>?> ListOrdersAndMenuItems(int reservationId);
        Task<IEnumerable<MenuItem>?> ListOrderedMenuItems(int reservationId);
        Task<decimal> CalculateAverageOrderAmount(int employeeId);
    }
}