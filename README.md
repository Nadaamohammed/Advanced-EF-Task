# Advanced EF Core – Product Management API

A RESTful Web API.

## 🚀 Features

- **Pagination:** Retrieve products in pages to reduce unnecessary data transfer.
- **Projection with `Select()`:** Retrieve only the required fields using DTOs.
- **No-Tracking Queries:** Use `AsNoTracking()` to improve read-only query performance.
- **N+1 Query Prevention:** Project related category data without executing a separate query for each product.
- **Database Indexing:** Create indexes on frequently searched fields to improve query performance.
- **Soft Delete:** Use the `IsDeleted` property and EF Core's `HasQueryFilter()` to hide deleted products from normal queries.
- **Change Tracking:** Track entity modifications and update only the allowed properties.

## 🛠️ Technologies Used

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- LINQ
- RESTful APIs
- DTOs
- Code-First Migrations

## 📂 Main Entities

### Product
Represents a product with properties such as:
- `Id`
- `Name`
- `Price`
- `CategoryId`
- `IsDeleted`
- `RowVersion`

### Category
Represents a product category and its relationship with products.

## 🔌 API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/products` | Retrieve products with pagination |
| GET | `/api/products?pageNumber=1&pageSize=10` | Retrieve a specific page |
| GET | `/api/products?search=phone` | Search products by name |
| PUT | `/api/products/{id}` | Update an existing product with concurrency validation |
| DELETE | `/api/products/{id}` | Soft-delete a product |

> **Note:** The endpoints listed above describe the intended API design. Update this section if your implemented routes differ.

## ⚡ Performance Optimization

### Pagination
Uses `Skip()` and `Take()` to retrieve a limited number of products per request.

### Projection
Uses `Select()` to return only the necessary properties instead of loading complete entities.

### No-Tracking Queries
Uses `AsNoTracking()` for read-only operations to reduce change-tracking overhead.

### N+1 Query Prevention
Projects category information as part of the product query to avoid executing an additional query for every product.

## 🗑️ Soft Delete

Instead of permanently removing products, the API sets `IsDeleted` to `true`.

EF Core's global query filter excludes soft-deleted products from normal queries:

```csharp
modelBuilder.Entity<Product>()
    .HasQueryFilter(p => !p.IsDeleted);
```
## ⚙️ Getting Started

### Prerequisites

- .NET SDK compatible with the project
- SQL Server
- Visual Studio or another .NET-compatible IDE

### 1. Clone the Repository

```bash
git clone <your-repository-url>
cd Advanced_EF
```

### 2. Configure the Database

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_SQL_SERVER_CONNECTION_STRING"
  }
}
```

### 3. Apply Database Migrations

Run the following commands in the Package Manager Console:

```powershell
Add-Migration InitialCreate
Update-Database
```

If migrations already exist, apply them with `Update-Database` instead of creating a duplicate initial migration.

### 4. Run the Application

Run the project from Visual Studio or use:

```bash
dotnet run
```

Use the configured application URL to access the API. If Swagger is enabled, open its URL to explore and test the endpoints.

## 👩‍💻 Author

**Nada Abdelrahman**

.NET Backend Developer
