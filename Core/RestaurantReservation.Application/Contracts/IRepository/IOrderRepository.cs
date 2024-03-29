﻿using RestaurantReservation.Application.DTOs;

namespace RestaurantReservation.Application.Contracts.IRepository
{
    public interface IOrderRepository : IEntityRepository<OrderDTO>
    {
        Task<IEnumerable<OrderWithMenuItemsDTO>> ListOrdersWithMenuItemsAsync(int reservationId);
        Task<IEnumerable<MenuItemDTO>> ListOrderedMenuItemsAsync(int reservationId);
        Task<decimal> CalculateAverageOrderAmountAsync(int employeeId);
    }
}
