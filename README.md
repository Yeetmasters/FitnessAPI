# FitnessAPI
FitnessAPI is a .NET Entity Framework Core API for connecting the Fitness App with an Azure SQL database.

It uses [Swagger](https://github.com/swagger-api) to try out the API calls directly in the browser.

## Installation

### Requirements
- Visual Studio 2019
- Azure SQL Database connection string

### NuGet Dependencies
- Microsoft.EntityFrameworkCore v3.19
- Microsoft.EntityFrameworkCore.SqlServer v3.19
- Microsoft.EntitryFrameworkCore.Tools v3.19
- Microsoft.VisualStudio.Web.CodeGeneration.Design v3.1.4
- Swashbuckle.AspNetCore v5.6.3

## Instructions
Open `Visual Studio 2019`, open `File -> Clone Repository`.

Clone the repository at ```https://github.com/Yeetmasters/FitnessAPI```

Create an `appsettings.json` file in the`\source\repos\FitnessAPI` directory, and paste the following:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "FitnessAppDBConnection":"YourAzureSQLConnectionStringHere"
  }
}
```
### Azure Deployment 
Open Build->Publish FitnessAPI, and follow the instructions to deploy to an Azure Web App.

You should be able to go to `yourwebsite.azurewebsites.net/index.html` to access the Swagger UI.

## Usage

### Models

Abstract an entity table. Fields go here. Create a new model for a new entity, add or remove fields here.
### Context

The external access point for your API. You need to add 
### Controllers

Define available HTTP queries. Only create controllers for models you want accessible to the internet.

### Migrations
Migrations are like git for the database. 

After making changes to models, open the PM console and enter: `Add-Migration migrationNameHere`

To revert changes, enter:`Revert-Migration migrationNameHere`

Once happy with your changes, write them to the database with `Update-Database`. This is irreversible.

## Contributing
Pull requests are not welcome.

## Copyright
Copyright © 2020 wsk9531 & brixBoi
