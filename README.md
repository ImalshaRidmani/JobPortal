# 🧑‍💻 Job Portal API

A RESTful Job Portal API built using **ASP.NET Core Web API**, **Entity Framework Core**, and **JWT Authentication** with **Role-Based Authorization (Employer / Employee)**.

---

## 🚀 Features

- User Registration (Employer / Employee)
- User Login with JWT Authentication
- Password Hashing (Secure storage)
- Role-Based Authorization
  - Employer → Create & manage job posts
  - Employee → View and apply for jobs
- Secure API endpoints using JWT
- Clean layered architecture (Controllers, Services, Repositories)
- Entity Framework Core with SQL Server

---

## 🛠️ Technologies Used

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- JWT (JSON Web Token)
- C#
- Swagger (API Testing)
- BCrypt / Password Hashing

---

## 📁 Project Structure

```
Controllers/      → API endpoints (Auth, Jobs)
Services/         → Business logic
Repositories/     → Data access layer
Models/           → Database entities
DTOs/             → Request/Response models
Data/             → DbContext
Migrations/       → EF Core migrations
Program.cs        → Application setup
```

---

## 🔐 Authentication Flow

1. User registers with role (Employer / Employee)
2. Password is hashed before saving to database
3. User logs in with email/password
4. Server validates credentials
5. JWT token is generated
6. Client stores token
7. Token is sent in every request
8. Backend validates token and role

---

## 📡 API Endpoints

### 🔐 Authentication

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/register` | Register new user |
| POST | `/api/auth/login` | Login and get JWT token |

---

### 💼 Jobs

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/jobs` | Get all jobs |
| POST | `/api/jobs` | Create job (Employer only) |

---

## 🧪 Sample Requests

### Register User
```json
{
  "username": "john",
  "email": "john@example.com",
  "password": "Password123",
  "role": "Employer"
}
```

---

### Login User
```json
{
  "email": "john@example.com",
  "password": "Password123"
}
```

---

## 🔑 JWT Authorization Header

```
Authorization: Bearer YOUR_JWT_TOKEN
```

---

## ⚙️ Setup & Run Project

### 1. Clone Repository
```bash
git clone https://github.com/your-username/JobPortalAPI.git
```

### 2. Update Database Connection
Edit `appsettings.json`

### 3. Run Migrations
```bash
dotnet ef database update
```

### 4. Run Project
```bash
dotnet run
```

---

## 📌 Future Improvements

- Job Application System
- Resume Upload Feature
- Email Notifications
- Refresh Token Implementation
- Pagination & Filtering
- Admin Dashboard

---

## 👨‍💻 Author

**Imalsha Ridmani**

---

## ⭐ Project Goal

This project demonstrates:
- JWT Authentication
- Role-based Authorization
- Clean architecture in ASP.NET Core
- Real-world backend API design
```
