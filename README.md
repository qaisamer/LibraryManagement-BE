# Library Management API

A simple ASP.NET Core Web API for managing books and categories in a library system.  
This project uses **SQL Server** as the database and provides endpoints for CRUD operations on books and categories.

---

## Table of Contents

- [Prerequisites](#prerequisites)  
- [Installation](#installation)  
- [Database Setup](#database-setup)  
- [Running the Application](#running-the-application)  
- [API Endpoints](#api-endpoints)  
- [Testing with Swagger](#testing-with-swagger)  
- [Contributing](#contributing)  
- [License](#license)  

---

## Prerequisites

Before running the application, make sure you have the following installed:

- [.NET SDK (8.0)](https://dotnet.microsoft.com/download)  
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  
- [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)  
- [Git](https://git-scm.com/)  

---

## Installation

1. Clone the repository:

git clone git@github.com:qaisamer/LibraryManagement-BE.git
cd LibraryManagement-BE
Build the project:

dotnet build
Database Setup
Open SQL Server Management Studio (SSMS) and connect to your SQL Server instance.

Create a new database (e.g., LibraryManagementDB).

Execute the following SQL scripts to create tables and seed data:


-- Create Database
CREATE DATABASE LibraryManagementDB;
GO

USE LibraryManagementDB;
GO

-- Create Categories Table
CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);
GO

-- Create Books Table
CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Author NVARCHAR(150) NULL,
    CategoryId INT NOT NULL,
    CONSTRAINT FK_Books_Category FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE CASCADE
);
GO

-- Create Stored Procedure
CREATE PROCEDURE GetAllBooksWithCategory
AS
BEGIN
    SELECT 
        b.Id AS BookId,
        b.Title,
        b.Author,
        c.Id AS CategoryId,
        c.Name AS CategoryName
    FROM Books b
    INNER JOIN Categories c
        ON b.CategoryId = c.Id
END
GO
Update the connection string in appsettings.json:

"ConnectionStrings": {
  "LibraryManagementConnection": "Server=YOUR_SERVER_NAME;Database=LibraryManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
Running the Application
From the project directory, run:

dotnet run
By default, the API will be available at:

https://localhost:7075
http://localhost:5002

Testing with Swagger
Swagger UI is included to easily test API endpoints. Open a browser and navigate to:

https://localhost:7075/swagger
http://localhost:5002/swagger
