# 📘 TaskManager - Documentación Técnica

Proyecto **TaskManager**: Sistema de gestión de tareas con autenticación, validaciones y arquitectura en capas.

---

## 📂 Arquitectura del Proyecto

La solución está organizada en **4 capas** principales:

```
TaskManager.sln
│
├── TaskManager.API          # Capa de presentación (endpoints, controllers, middlewares)
├── TaskManager.Application  # Capa de aplicación (DTOs, servicios, lógica de negocio)
├── TaskManager.Domain       # Capa de dominio (entidades, reglas de negocio)
├── TaskManager.Persistence  # Capa de persistencia (DbContext, repositorios, migraciones)
```

- **API** → Controllers + Middlewares (ej. BasicAuth, JWT, validaciones globales).  
- **Application** → DTOs + servicios + AutoMapper.  
- **Domain** → Entidades principales (`Task.cs`, etc).  
- **Persistence** → PostgreSQL con EF Core (DbContext + migraciones).  

---

## ⚙️ Tecnologías Utilizadas

- **.NET 8** (Web API)
- **PostgreSQL** (base de datos relacional)
- **Entity Framework Core** (ORM)
- **AutoMapper** (mapear entidades ↔ DTOs)
- **JWT (JSON Web Token)** (autenticación segura)
- **Docker + Docker Compose** (contenedorizar DB y pgAdmin)
- **Swagger / OpenAPI** (documentación de endpoints)

---

## 🚀 Configuración y Ejecución

### 1️⃣ Clonar el repositorio
```bash
git clone https://github.com/d/taskmanager.git
cd taskmanager
```

### 2️⃣ Configurar base de datos
En `appsettings.json` dentro de **TaskManager.API**:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=taskmanager;Username=postgres;Password=postgres"
}
```

### 3️⃣ Ejecutar con Docker
```bash
docker-compose up -d
```

Esto levanta:
- PostgreSQL → `localhost:5432`
- pgAdmin → `localhost:8080`

### 4️⃣ Migraciones de EF Core
```bash
dotnet ef database update --project TaskManager.Persistence --startup-project TaskManager.API
```

### 5️⃣ Ejecutar API
```bash
dotnet run --project TaskManager.API
```

La API estará disponible en 👉 **http://localhost:5049/swagger**

---

## 🔐 Seguridad

### 🔸 Autenticación Básica
Middleware `BasicAuthMiddleware.cs` que protege endpoints iniciales.

### 🔸 JWT
Configuración en `Program.cs` y `JwtSettings.cs`.  
Endpoints de login en `AuthController.cs`.

Ejemplo de login:
```http
POST /api/auth/login
Content-Type: application/json

{
  "username": "admin",
  "password": "12345"
}
```

Respuesta:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR..."
}
```

---

## ✅ Validaciones

Se utilizan **DataAnnotations** y filtros globales para manejo de errores.  

Ejemplo en `TaskDto.cs`:
```csharp
[Required]
[StringLength(100)]
public string Title { get; set; }

[DateRange("2024-01-01", "2025-12-31")]
public DateTime StartDate { get; set; }

[DateRange("2024-01-01", "2025-12-31")]
public DateTime EndDate { get; set; }
```

---

## 📌 Endpoints principales

| Método | Endpoint        | Descripción                     | Seguridad |
|--------|-----------------|---------------------------------|-----------|
| POST   | `/api/auth/login` | Generar token JWT               | Público   |
| GET    | `/api/tasks`      | Listar todas las tareas         | JWT       |
| POST   | `/api/tasks`      | Crear una nueva tarea           | JWT       |
| PUT    | `/api/tasks/{id}` | Actualizar una tarea existente  | JWT       |
| DELETE | `/api/tasks/{id}` | Eliminar una tarea              | JWT       |

---

## 🛠️ Scripts Útiles

- Crear migración:
```bash
dotnet ef migrations add Init --project TaskManager.Persistence --startup-project TaskManager.API
```

- Actualizar base de datos:
```bash
dotnet ef database update --project TaskManager.Persistence --startup-project TaskManager.API
```

- Limpiar y compilar:
```bash
dotnet clean && dotnet build
```

---

## 📖 Próximos pasos

- [ ] Implementar pruebas unitarias con **xUnit**
- [ ] Configurar **CI/CD con GitHub Actions**
- [ ] Implementar **refresh tokens**
- [ ] Agregar **roles y permisos**

---

## 👩‍💻 Autora

**Vanessa Duarte**  
🔗 GitHub: [github.com/dvanessa](https://github.com/dvanessa)
