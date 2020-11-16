# DfE .net core template

## About

A .net core template for DfE sites, using GDS styles complied with webpack, Azure AD for auth and EF Core for ORM

### Dependencies and technologies

Technologies used:

- ASP.Net Core sdk 3.1.2
- Entity Framework Core 3.1.2
- Webpack 4
- Azure AD

## Installation

### 1. Update the user secrets

This project uses the ASP.NET Core [Secret Manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets) to store sesitive data. If using Visual Studio, right-click on each web project specified below and select "Manage User Secrets" - fill in `secrets.json` with the following:

```json
{
  "ConnectionStrings": {
    "Connection": "Server=(localdb)\\mssqllocaldb;Database=Data;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "AzureAd": {
    "ClientSecret": "...",
    "Domain": "...",
    "TenantId": "...",
    "ClientId": "..."
  },
  "Keys": {
    "GoogleAnalyticsKey": "..."
  },
  "ApplicationInsights": {
    "InstrumentationKey": "..."
  }
}
```

### 2. Update the database

```console
# update database (from the CLI at ./src/)
dotnet ef database update --startup-project DfESurveyTool.Web --project DfESurveyTool.Data
```

#### Adding migrations with EF 3

Add a migration using the below command, using a name describing the data changes you're applying.

```console
# create migration (from the CLI at ./src/)
dotnet ef migrations add NameOfMigration --context DfESurveyToolDbContext --startup-project DfESurveyTool.Web --project DfESurveyTool.Data
```

### 3. Build process for static files

- Download node.js

- Either
  run node.js cmd prompt as an administator
  or
  run a cmd prompt from inside your ide e.g. vscode or visual studio

- Navigate to the web project folder (containing the package.json file) that you want to use
  e.g: `./src/DfESurveyTool.Web` and install the node dependencies:

```js
 npm ci
```

- Then, build the web application using [Webpack](https://webpack.js.org/):

```js
# production settings
npm run build

# dev settings - automatically recompiles when changes are made
npm run dev
```
