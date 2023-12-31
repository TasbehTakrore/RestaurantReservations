﻿using AutoMapper;
using FluentResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Mapper;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Services;

IConfiguration configuration = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

var serviceProvider = new ServiceCollection()
    .Configure<DbContextOptions>(configuration.GetSection("DbContextOptions"))
    .AddDbContext<RestaurantReservationDbContext>()
    .BuildServiceProvider();

var _dbContext = serviceProvider.GetRequiredService<RestaurantReservationDbContext>();


var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
IMapper mapper = new Mapper(config);


var customerRepository = new CustomerRepository(_dbContext);
var customerService = new CustomerService(customerRepository, mapper);

var employeeRepository = new EmployeeRepository(_dbContext);
var employeeService = new EmployeeService(employeeRepository, mapper);

var reservationRepository = new ReservationRepository(_dbContext);
var reservationService = new ReservationService(reservationRepository, mapper);

var orderRepository = new OrderRepository(_dbContext);
var orderService = new OrderService(orderRepository, mapper);

var restaurantRepository = new RestaurantRepository(_dbContext);
var restaurantService = new RestaurantService(restaurantRepository, mapper);

//await ListManagersAsync(employeeService);
//await GetReservationsByCustomerAsync(reservationService, 4);
//await ListOrdersAndMenuItemsAsync(orderService, 9);
//await ListOrderedMenuItemsAsync(orderService, 9);
//await CalculateAverageOrderAmountAsync(orderService, 4);
//await FindCustomersByPartySizeAsync(customerService, PartySize.mediam);
//await ListReservationsDetailsViewAsync(reservationService);
//await ListEmployeesWithRestaurantDetailsViewAsync(employeeService);
await CalculateTotalRevenueAsync(restaurantService, 5);

async Task CalculateAverageOrderAmount(OrderService orderService, int employeeId)
{
    (decimal avgOrderAmount, Result result) = await orderService.CalculateAverageOrderAmountAsync(employeeId);

    if (result.IsSuccess)
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Average Order Amount: {avgOrderAmount}");
    }
    else
    {
        result.Errors.ForEach(e => Console.WriteLine($"Failed: {e.Message}"));
    }
}

async Task CalculateTotalRevenueAsync(RestaurantService restaurantService, int restaurantId)
{
    (decimal? totalRevenue, Result result) = await restaurantService.CalculateTotalRevenueAsync(restaurantId);

    if (result.IsSuccess)
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Total Revenue: {totalRevenue}");
    }
    else
    {
        result.Errors.ForEach(e => Console.WriteLine($"Failed: {e.Message}"));
    }
}

async Task ListReservationsDetailsViewAsync(ReservationService service)
{
    (var reservationsDetails, var result) = await service.ListReservationsDetailsViewAsync();
    if (result.IsSuccess)
    {
        Console.WriteLine("------------------------------");
        foreach (var reservationDetails in reservationsDetails)
        {
            Console.WriteLine(reservationDetails);
        }
        Console.WriteLine("------------------------------");
    }
    else
    {
        result.Errors.ForEach(e => Console.WriteLine($"Failed: {e.Message}"));
    }
}

async Task ListEmployeesWithRestaurantDetailsViewAsync(EmployeeService service)
{
    (var EmployeesWithRestaurantDetails, var result) = await service.ListEmployeesWithRestaurantDetailsViewAsync();
    if (result.IsSuccess)
    {
        Console.WriteLine("------------------------------");
        foreach (var employee in EmployeesWithRestaurantDetails)
        {
            Console.WriteLine(employee);
        }
        Console.WriteLine("------------------------------");
    }
    else
    {
        result.Errors.ForEach(e => Console.WriteLine($"Failed: {e.Message}"));
    }
}

async Task ListOrderedMenuItemsAsync(OrderService service, int reservationId)
{
    (var orderedMenuItems, var result) = await service.ListOrderedMenuItemsAsync(reservationId);
    if (result.IsSuccess)
    {
        Console.WriteLine("------------------------------");
        foreach (var menuItem in orderedMenuItems)
        {
            Console.WriteLine(menuItem);
        }
        Console.WriteLine("------------------------------");
    }
    else
    {
        result.Errors.ForEach(e => Console.WriteLine($"Failed: {e.Message}"));
    }
}

async Task FindCustomersByPartySizeAsync(CustomerService service, PartySize partySize)
{
    (var customers, var result) = await service.FindCustomersByPartySizeAsync(partySize);
    if (result.IsSuccess)
    {
        Console.WriteLine("------------------------------");
        foreach (var customer in customers)
        {
            Console.WriteLine(customer);
        }
        Console.WriteLine("------------------------------");
    }
    else
    {
        result.Errors.ForEach(e => Console.WriteLine($"Failed: {e.Message}"));
    }
}

async Task ListOrdersAndMenuItemsAsync(OrderService service, int reservationId)
{
    (var ordersWithMenuItemsDTOs, var result) = await service.ListOrdersAndMenuItemsAsync(reservationId);
    if (result.IsSuccess)
    {
        Console.WriteLine("------------------------------");
        foreach (var orderWithMenuItemsDTO in ordersWithMenuItemsDTOs)
        {
            Console.WriteLine(orderWithMenuItemsDTO);
        }
        Console.WriteLine("------------------------------");
    }
    else
    {
        result.Errors.ForEach(e => Console.WriteLine($"Failed: {e.Message}"));
    }
}

async Task GetReservationsByCustomerAsync(ReservationService service, int customerId)
{
    (var data, var result) = await service.GetReservationsByCustomerAsync(customerId);
    if (result.IsSuccess)
    {
        Console.WriteLine("------------------------------");
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("------------------------------");
    }
    else
    {
        result.Errors.ForEach(e => Console.WriteLine($"Failed: {e.Message}"));
    }
}

async Task ListManagersAsync(EmployeeService service)
{
    (var data, var result) = await service.ListManagersAsync();
    if (result.IsSuccess)
    {
        Console.WriteLine("------------------------------");
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("------------------------------");
    }
    else
    {
        result.Errors.ForEach(e => Console.WriteLine($"Failed: {e.Message}"));
    }
}