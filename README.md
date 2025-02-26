# Product Management System

## Overview
This project is a Product Management System built using ASP.NET Core. It provides a RESTful API for managing products, including functionalities for creating, reading, updating, and deleting product information.

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [PostgreSQL](https://www.postgresql.org/download/) for the database
- An IDE such as [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Getting Started

### Clone the Repository
### Setup Database
1. Create a PostgreSQL database.
2. Update the connection string in `appsettings.json`:
### Install Dependencies
Run the following command to restore the project dependencies:
### Run Migrations
To create the database schema, run:
### Start the Application
Run the application using:
### Access the API
Once the application is running, you can access the API at `https://localhost:5001/api/products`.

### Swagger UI
For API documentation and testing, navigate to `https://localhost:5001/swagger` in your browser.

## Testing
The project includes integrated unit tests. To run the tests, use:
## Contributing
1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes and commit them (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a pull request.

