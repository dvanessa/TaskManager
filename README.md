# TaskManager 🚀

Proyecto de **gestión de tareas** desarrollado con **.NET 8** y **PostgreSQL**, siguiendo arquitectura en capas (API, Application, Domain, Persistence).  

## 🔑 Características
- API REST con **.NET 8**
- **Entity Framework Core** + PostgreSQL
- **JWT Authentication**
- **AutoMapper** para mapeo de DTOs
- Contenedores con **Docker + pgAdmin**
- Documentación con **Swagger**

## 🚀 Cómo ejecutar
```bash
docker-compose up -d
dotnet ef database update --project TaskManager.Persistence --startup-project TaskManager.API
dotnet run --project TaskManager.API

