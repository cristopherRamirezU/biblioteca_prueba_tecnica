# Prueba Técnica - Biblioteca (VISTA TI)

Proyecto de prueba técnica para el cargo de Desarrollador Junior en VISTA TI.

## 📋 Descripción

Aplicación web que permite buscar libros utilizando una API pública (OpenLibrary).

Actualmente el proyecto incluye:

- Backend en .NET Web API.
- Conexión a base de datos SQL Server.
- Script SQL para crear la base de datos.
- Endpoint para búsqueda de libros en OpenLibrary.

---

## 🗂️ Estructura del proyecto

- /backend : API REST en .NET
- /frontend : Frontend en Angular (aún no implementado)
- /database : Scripts SQL para crear la base de datos

---

## 🗄️ Base de datos

En la carpeta `/database` se incluye el script:

- `create_db.sql`

Este script:

- Crea la base de datos `BibliotecaDb`
- Crea las tablas `Users` y `Favorites`
- Agrega restricciones para evitar duplicados
- Inserta un usuario inicial de prueba

### ▶️ Cómo ejecutar el script

1. Abrir SQL Server Management Studio
2. Abrir el archivo `create_db.sql`
3. Ejecutarlo con el botón **Execute**

---

## ⚙️ Backend (.NET)

### ✅ Requisitos

- .NET SDK 8
- SQL Server (Express o Developer)

### ▶️ Cómo ejecutar el backend

Desde la carpeta:

/backend/Biblioteca.Api


Ejecutar:

```bash
dotnet run


La API quedará disponible en:

http://localhost:5015


Swagger:

http://localhost:5015/swagger

🌐 Endpoint implementado
🔍 Buscar libros
GET /api/books/search?query=harry


Este endpoint:

-Consulta la API pública de OpenLibrary

-Normaliza los datos

-Devuelve una lista de libros

🧠 Arquitectura

El backend utiliza una arquitectura en capas:

-Controllers

-Services

-ExternalClients

-DTOs

-Models

-Data (DbContext)

🚧 Estado del proyecto

✅ Estructura base del backend creada

✅ Base de datos lista con script SQL

✅ Entity Framework configurado

✅ Integración con OpenLibrary funcionando

⏳ Sistema de favoritos pendiente

⏳ Frontend pendiente

⏳ Tests unitarios pendientes