## Project Overview
.The Salary project is designed to calculate overtime payments for individuals across different months and store fee, commuting fee, and additional working hours per month of each person along with their personal information. This application utilizes the power of .NET7 technology along with the SQL Server Database and Entity Framework Core ORM (Object-Relational Mapping) for efficient data storage and retrieval.

## Project Features
.Overtime Payment Calculation: Users can input personal information, monthly salary data, fee, commuting fee, and additional working hours per month to calculate the overtime payment for an individual during a specific month.

.Store Payment and Salary Information: The application stores the calculated overtime payment information, fee, commuting fee, additional working hours, and associated personal details in the SQL Server database using Entity Framework Core ORM.

.Retrieve Payment Data: Authorized users can query the database to retrieve and view the stored overtime payment information, fee, commuting fee, and additional working hours for any individual and month.

## Technologies Used

.NET 7

NET 7 serves as the foundation for building the Salary application, providing a robust and scalable framework for web development. The application is developed using C# as the primary programming language and leverages ASP.NET Core for web application development.


.SQL Server Database and Entity Framework Core ORM

SQL Server Database is chosen as the data storage solution for this project due to its reliability and strong data management capabilities.
Entity Framework Core ORM is employed to interact with the SQL Server database. This approach simplifies data access by mapping database objects to C# classes, making database interactions more abstract and developer-friendly.

## Getting Started
1. Install .NET SDK: Before running the application, make sure you have the .NET SDK installed on your machine.
2. Set up SQL Server Database: The application uses a SQL Server database to store data. Ensure you have SQL Server installed and running on your machine.
3. Clone the Project Repository: Clone the Salary project repository from GitHub.

4. Open the Project in IDE: Use your preferred Integrated Development Environment (IDE) like Visual Studio or Visual Studio Code to open the project.

5. Update Connection String: In the project, locate the appsettings.json file. Inside this file, find the "ConnectionStrings" section. Update the "SalaryDatabase" value with your actual SQL Server connection details, including the server address, database name, username, and password.

6. Apply Migrations: In the terminal or command prompt, navigate to the project directory. Run the command to apply migrations: dotnet ef migrations add InitialCreate. This will create a new migration based on the changes in the application's models.

7. Update Database: After creating the migration, run the command: dotnet ef database update. This will apply the migration to the database and create the necessary tables.

8. Build and Run the Application.

9. Access the Application: Open a web browser and navigate to the specified local address to access the Salary application.

## Acknowledgments
We would like to express our gratitude to the .NET and SQL Server communities for their valuable tools and resources that helped make this project possible.
