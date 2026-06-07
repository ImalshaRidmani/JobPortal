# Job Portal API

A RESTful Job Portal API built with ASP.NET Core Web API, Entity Framework Core, SQL Server, and JWT Authentication.

## Features

- User Registration
- User Login
- Password Hashing
- JWT Authentication
- Role-Based Authorization
  - Employer
  - Employee
- Create Job Posts
- View Job Posts
- Secure API Endpoints

## Technologies Used

- ASP.NET Core 8 Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- BCrypt Password Hashing
- Swagger/OpenAPI

## Project Structure

```
Controllers/
Models/
DTOs/
Data/
Services/
Program.cs
```

## Authentication Flow

1. User registers with a role (Employer or Employee)
2. Password is hashed before saving
3. User logs in
4. JWT token is generated
5. Client sends token in Authorization header
6. API validates token and authorizes requests

## API Endpoints

### Authentication

| Method | Endpoint |
|----------|----------|
| POST | /api/auth/register |
| POST | /api/auth/login |

### Jobs

| Method | Endpoint |
|----------|----------|
| GET | /api/jobs |
| POST | /api/jobs |

## Sample Register Request

```json
{
  "username": "john",
  "email": "john@example.com",
  "password": "Password123",
  "role": "Employer"
}
```

## Sample Login Request

```json
{
  "email": "john@example.com",
  "password": "Password123"
}
```

## Running the Project

1. Clone the repository

```bash
git clone https://github.com/yourusername/JobPortalAPI.git
```

2. Update connection string in appsettings.json

3. Run migrations

```bash
dotnet ef database update
```

4. Run project

```bash
dotnet run
```

## Future Improvements

- Job Applications
- Resume Upload
- Email Notifications
- Refresh Tokens
- Pagination & Filtering

## Author

Imalsha Ridmani
