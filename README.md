# TaskManager API

API para gestión de tareas construida con ASP.NET Core 8, PostgreSQL, Entity Framework Core, y autenticación con JWT.

## Funcionalidades

- Crear, leer, actualizar y eliminar tareas
- Autenticación básica con login por token JWT
- Validaciones con Data Annotations
- AutoMapper para DTOs
- Swagger UI para pruebas de endpoints

## Requisitos

- .NET SDK 8.0 o superior
- PostgreSQL (puede usarse vía Docker)
- Visual Studio Code o editor compatible

## Uso

1. Clonar el repositorio
2. Configurar `appsettings.json` con tu cadena de conexión
3. Ejecutar migraciones
4. Iniciar el proyecto con `dotnet run`

## Swagger

Después de ejecutar el proyecto, visita:
https://localhost:7164/swagger
