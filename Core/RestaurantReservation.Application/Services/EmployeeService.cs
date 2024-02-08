﻿using AutoMapper;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.Domain.Repositories.IRepositories;
using RestaurantReservation.Domain.Services.IServices;
using FluentResults;

namespace RestaurantReservation.Domain.Services
{
    public class EmployeeService : EntityService<Employee, EmployeeDTO, IEmployeeRepository>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) : base(employeeRepository, mapper)
        {
        }

        public async Task<(IEnumerable<EmployeeDTO>?, Result)> ListManagersAsync()
        {
            try
            {
                var employees = await _entityRepository.ListManagersAsync();
                var dtos = MapEntityToDto(employees);
                return (dtos, Result.Ok());
            }
            catch (Exception ex)
            {
                return (null, Result.Fail(ex.Message));
            }
        }

        public async Task<(IEnumerable<EmployeesWithRestaurantDetailsDTO>?, Result)> ListEmployeesWithRestaurantDetailsAsync()
        {
            try
            {
                var employees = await _entityRepository.ListEmployeesWithRestaurantDetailsAsync();
                var dtos = MapEntityToDto<EmployeesWithRestaurantDetails, EmployeesWithRestaurantDetailsDTO>(employees);
                return (dtos, Result.Ok());
            }
            catch (Exception ex)
            {
                return (null, Result.Fail(ex.Message));
            }
        }
    }
}