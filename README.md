📚 Biblioteca – Prueba Técnica Fullstack

Este proyecto corresponde a una prueba técnica fullstack para VISTA TI.
Consiste en una aplicación web que permite buscar libros desde OpenLibrary, guardarlos en favoritos y administrarlos mediante una API propia.

La solución está dividida en:

✅ Backend en .NET

✅ Frontend en Angular

✅ Persistencia en base de datos

✅ Tests automatizados con xUnit

🧱 Estructura del proyecto
biblioteca_prueba_tecnica/
├── backend/
│   ├── Biblioteca.Api
│   └── Biblioteca.Api.Tests
├── frontend/
│   └── biblioteca-frontend
└── database/
    └── create_database.sql

🚀 Funcionalidades

🔍 Buscar libros usando OpenLibrary

📄 Mostrar resultados con título, autor, año y portada

❤️ Agregar libros a favoritos

⭐ Listar favoritos guardados

🗑️ Eliminar favoritos

🧪 Tests automatizados del backend

💾 Persistencia en base de datos

⚙️ Tecnologías usadas
Backend

.NET

ASP.NET Web API

Entity Framework Core

SQLite (para ejecución local)

Swagger

xUnit

Frontend

Angular

TypeScript

HTML

HttpClient

🖥️ Cómo ejecutar el proyecto
1️⃣ Backend

Desde la carpeta:

/backend/Biblioteca.Api


Ejecutar:

dotnet restore
dotnet run


El backend queda disponible en:

http://localhost:5015


Swagger:

http://localhost:5015/swagger

2️⃣ Frontend

Desde la carpeta:

/frontend/biblioteca-frontend


Ejecutar:

npm install
ng serve


Abrir en el navegador:

http://localhost:4200

🧪 Ejecutar tests

Desde:

/backend/Biblioteca.Api.Tests


Ejecutar:

dotnet test


Resultado esperado:

Total: 5
Correctas: 5
Fallidas: 0

🗃️ Base de datos
📄 Script DDL (SQL Server)

En la carpeta:

/database/create_database.sql


Se incluye un script DDL para SQL Server que:

Crea la base de datos BibliotecaDb

Crea las tablas Users y Favorites

Crea la relación entre tablas

Crea un índice único para evitar duplicados

Inserta un usuario inicial

▶️ Cómo ejecutar el script manualmente (requerido por el enunciado)

Abrir SQL Server Management Studio

Abrir el archivo:

/database/create_database.sql


Ejecutarlo

Configurar el connection string en:

/backend/Biblioteca.Api/appsettings.json


Ejemplo:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BibliotecaDb;Trusted_Connection=True;TrustServerCertificate=True;"
}


Cambiar el provider en Program.cs a:

UseSqlServer(...)

▶️ Modo actual de ejecución (para facilidad del evaluador)

Por simplicidad, el proyecto está configurado actualmente para usar SQLite, lo que permite:

Ejecutar el backend directamente con:

dotnet run


La base de datos y tablas se crean automáticamente usando Entity Framework

Esto no elimina el uso del script SQL Server, el cual se entrega completo según lo solicitado en el enunciado.

🧠 Decisiones técnicas

Arquitectura en capas:

Controllers

Services

Repositories

Uso de inyección de dependencias

Validación para evitar favoritos duplicados

El frontend solo consume la API propia (no llama directo a OpenLibrary)

Manejo de estados de carga (loading)

Manejo de errores HTTP

Tests unitarios con mocks

🔁 Flujo de la aplicación

El frontend busca libros en la API

La API consulta OpenLibrary

El frontend muestra los resultados

El usuario puede:

Agregar a favoritos

Ver favoritos

Eliminar favoritos

Todo se guarda en la base de datos

🏁 Estado del proyecto

✅ Backend completo

✅ Frontend funcional

✅ Tests pasando

✅ Persistencia funcionando

✅ CRUD de favoritos completo

👤 Autor

Cristopher Ramírez

⚠️ Nota honesta

Por simplicidad de ejecución y revisión, el proyecto corre actualmente con SQLite, pero se entrega el script DDL en SQL Server tal como solicita el enunciado, y el proyecto está preparado para cambiar de provider sin cambios de arquitectura.