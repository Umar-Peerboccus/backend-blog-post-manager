# backend-blog-post-manager
RESTful API to implement CRUD operations for managing blog posts

# Design Choice
- The API is designed to be RESTful
- I used the CQRS Design Pattern to separate the read and write operations.
- This allows for better scalability and maintainability.
- I used the MediatR library to implement the CQRS pattern.
- I used the Repository Pattern to abstract the data access layer making the code more testable and maintainable.
- Therefore, when using the Repository Pattern, the Dependency Inversion Principle is also applied.
- I used the FluentValidation library to validate the incoming requests.
- I used the AutoMapper library to map the domain models to the DTOs.
- I used NoSql database from Azure Cosmos DB to store the data in JSON format.


# Getting Started
# Clone the repository
git clone https://github.com/Umar-Peerboccus/backend-blog-post-manager.git
Navigate to backend-blog-post-manager

# Install dependencies
dotnet restore

# Run the application
Navigate to Blog.Post.Manager.Backend.Api
dotnet run


