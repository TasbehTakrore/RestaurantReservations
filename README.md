# Restaurant Reservation System

This project is a .NET Core solution for managing restaurant reservations. It includes a database schema, data models, migrations, and various functionalities related to reservations, orders, and employees.

## Getting Started

### Prerequisites
- .NET Core 5.0 or later
- SQL Server Management Studio (SSMS)

### Setup

1. **Database Setup**
   - Create a new database named **RestaurantReservationCore** using SQL Server Management Studio.

2. **Projects Setup**
   - Clone this repository to your local machine.
   - Open the solution in Visual Studio.

3. **Database Migration**
   - Open the Package Manager Console in Visual Studio.
   - Run the following command to apply migrations and seed the database:
     ```
     Update-Database
     ```

4. **Run the Console Application**
   - Set the **RestaurantReservation** project as the startup project.
   - Run the application to see a demonstration of various functionalities.

## Project Structure

- **RestaurantReservation**: Console application project.
- **RestaurantReservation.Db**: Library project containing the database context, data models, migrations, and repositories.
- **Repositories**: Folder containing repository classes for each entity.
- 
## Database Schema
![Capture](https://github.com/TasbehTakrore/RestaurantReservations/assets/71009816/4eb2f8e4-eb53-4542-8513-abcd2e6a506c)

## Functionality

1. **Create/Update/Delete Methods**
   - Methods to manage entities: Employees, Customers, Restaurants, Reservations, Orders, MenuItems.

2. **ListManagers()**
   - Retrieve all employees who hold the position of "Manager."

3. **GetReservationsByCustomer(CustomerId)**
   - Retrieve reservations made by a specific customer.

4. **ListOrdersAndMenuItems(ReservationId)**
   - List orders and associated menu items for a specific reservation.

5. **ListOrderedMenuItems(ReservationId)**
   - List menu items ordered in a specific reservation.

6. **CalculateAverageOrderAmount(EmployeeId)**
   - Calculate the average order amount for a specific employee.

7. **Database Views**
   - Use EF Core to query views for reservations with customer and restaurant information, and employees with restaurant details.

8. **Database Functions**
   - Create a function to calculate the total revenue generated by a specific restaurant.

9. **Stored Procedures**
   - Design a stored procedure to find customers who have made reservations with a party size greater than a certain value.
  
     
## Advanced Features

### 1. Asynchronous Programming with LINQ
   - Utilized asynchronous methods in LINQ queries to enhance database interaction performance.

### 2. Git Best Practices
   - Followed Git best practices for version control.
   - Commits are made at the end of each project phase with meaningful messages describing implemented changes.

### 3. Database Views
   - Leveraged Entity Framework Core to create views for complex queries.
   - Implemented a view listing all reservations with associated customer and restaurant information.

### 4. Database Functions
   - Created a database function to calculate the total revenue generated by a specific restaurant.
   - Integrated the function call within the application.

### 5. Stored Procedures
   - Designed a stored procedure to find customers who made reservations with a party size greater than a certain value.
   - Implemented a method in the RestaurantReservation.Db project to execute the stored procedure.

### 6. Repository Pattern
   - Implemented a repository class for each entity (Employees, Customers, Restaurants, Reservations, Orders, MenuItems).
   - Organized repositories in a 'Repositories' folder within the RestaurantReservation.Db project.


## Acknowledgments

- This project follows best practices for .NET Core development.
- Feel free to contribute or open issues for improvements.
