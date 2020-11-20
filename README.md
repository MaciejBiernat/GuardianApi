# GuardianNews

The project is an MVC web application collecting data from external Api (Guardian). 

## Technology 
- ASP.net (mvc)
- Razor Pages
- Entity Framework Core
- SQL server

## Status
Still needs refactoring and improvement.  


## Getting Started

- Clone the repository using the command `git clone https://github.com/MaciejBiernat/GuardianApi`.
- In .NET Core CLI install global tool write `dotnet tool install --global dotnet-ef`
- In .NET Core CLI set Project directory and write `dotnet ef database update` 
- Play In Visual Studio.

## Important!
For the purpose of testing after succesfull registration browse to `https://localhost:44390/administration/createrole` then click on the "Add Role" button to change user role to "Admin".
Getting "Admin" role for your accout will enable Guardian Api getting data option.

