# Book Library API

A simple web API for managing a book library, built with .NET 8. 
This API allows users to perform CRUD operations on books, including adding, retrieving, updating, and deleting books.

## Features

- **Add** new books to the library
- **Retrieve** all books or a single book by ID
- **Update** details of a specific book
- **Delete** a book from the library

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Getting Started

### 1. Clone the Repository


```bash
git clone https://github.com/al-loco/BookLibrary.git
```

### 2. Using a CLI, individually run the following commands:

```
cd \BookLibrary\BookLibraryApi
dotnet restore
dotnet run
```

### 3. Open the APIs in Swagger

Using the port number displayed in the console
Go to https://localhost:<port>/swagger to test the api in the swagger interface.
Otherwise you can test using Postman.

### 4. Running Tests

Unit tests are included in the TestBookLibraryApi project.
These can be run in Visual Studio's Test Explorer, or in a CLI with the command:

```
cd \BookLibrary\TestBookLibraryApi
dotnet test
```

## Author
- [Alan Lockton](https://github.com/al-loco)