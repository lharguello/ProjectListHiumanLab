# 🛠️ Project Management API (.NET 9)

Una API RESTful desarrollada con ASP.NET Core (.NET 9) que permite gestionar una lista de proyectos. Esta API está construida siguiendo buenas prácticas y patrones comunes, incluyendo validación, mapeo de objetos, manejo de excepciones, documentación Swagger y almacenamiento en memoria.

---

## 🚀 Características

- CRUD completo para proyectos (Id, Nombre, Descripción, Estado)
- Validación de datos con **FluentValidation**
- Manejo global de errores
- AutoMapper para mapeo entre entidades y DTOs
- Documentación interactiva con **Swagger**
- Almacenamiento de datos **en memoria**
- Arquitectura limpia y modular

---

## 🏗️ Estructura del Proyecto

```
TaskManager
├── Behaviors             # Middleware personalizado (e.g. manejo de errores)
├── Controllers           # Controladores de la API
├── Domain                # Comportamientos reutilizables (middleware, excepciones)
│   └── DTOs              # Objetos de transferencia de datos
│   └── Entities          # Modelos de dominio (Project)
├── Helper                # Clases utilitarias o estáticas
├── Mappers               # Configuraciones de AutoMapper
├── Validators            # Reglas de validación con FluentValidation
├── appsettings.json      # Configuración general de la app
├── Program.cs            # Punto de entrada principal
└── TaskManager.http      # Pruebas rápidas de la API vía REST Client
```

---

## 📦 Requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

---

## ▶️ Cómo Ejecutar

```bash
dotnet restore
dotnet build
dotnet run
```

La API estará disponible en: `https://localhost:7190/swagger/index.html`

---

## 📋 Endpoints Principales

| Método | Endpoint           | Descripción                |
|--------|--------------------|----------------------------|
| GET    | /api/projects      | Obtener todos los proyectos |
| GET    | /api/projects/{id} | Obtener proyecto por ID    |
| POST   | /api/projects      | Crear nuevo proyecto       |
| PUT    | /api/projects/{id} | Actualizar un proyecto     |
| DELETE | /api/projects/{id} | Eliminar un proyecto       |

---

## 📘 Ejemplo de Objeto Proyecto

```json
{
  "name": "Nueva plataforma",
  "description": "Desarrollo de una nueva plataforma web",
  "status": "InProgress"
}
```

---

## 🧪 Tecnologías Utilizadas

- ASP.NET Core 9
- AutoMapper
- FluentValidation
- Swagger / Swashbuckle
- In-Memory Database
