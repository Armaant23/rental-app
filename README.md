# RentalApp

## Project Overview
---


This project is a rental app made using .NET MAUI.

Users can:
- create items
- edit items
- delete items
- request rentals
- view rental requests
- approve or reject requests

The project was built using MVVM, services, repositories, unit testing, and GitHub Actions.


---

## Technologies Used

- .NET 10
- .NET MAUI
- Entity Framework Core
- PostgreSQL
- xUnit
- GitHub Actions

---

## Project Structure

- StarterApp/ → main MAUI app
- StarterApp.Database/ → database models and repositories
- StarterApp.Migrations/ → database migrations
- StarterApp.Test/ → unit tests

---

## Setup Instructions

### Clone the repository

```bash
git clone https://github.com/Armaant23/rental-app
```

---

## Open in VS Code

Open the project folder in VS Code and reopen the project in the dev container.

---

## Build the project

```bash
dotnet build
```

---

## Run tests

```bash
dotnet test StarterApp.Test/StarterApp.Test.csproj
```

---

## Main Features

- user login
- create item listings
- edit items
- delete items
- rental requests
- incoming and outgoing requests
- approve and reject rentals
- duplicate request prevention
- total rental price calculation
- unit testing
- GitHub Actions CI/CD

---

## Architecture Overview

The project uses MVVM architecture.

- Views handle the UI
- ViewModels handle page logic
- Services handle business logic
- Repositories handle database access

---

## API Reference

API documentation:

https://set09102-api.b-davison.workers.dev/

---

## Testing

xUnit was used for unit testing.

Current tests include:
- rental model tests
- default value tests
- basic validation tests

---

## CI/CD

GitHub Actions was added to:
- restore dependencies
- build the project
- run tests automatically

---
## AI Tool Usage

ChatGPT was used when developing for:
- debugging
- fixing build issues
- MVVM guidance
- repository pattern help
- CI/CD setup help

All code was checked and tested before being added to the project.
