📚 Biblioteca – Prueba Técnica Fullstack

Este proyecto corresponde a una prueba técnica fullstack donde desarrollé una aplicación para buscar libros desde OpenLibrary, guardarlos en favoritos y administrarlos desde una API propia.

La solución está dividida en:

✅ Backend en .NET

✅ Frontend en Angular

✅ Base de datos SQLite

✅ Tests automatizados con xUnit

🧱 Estructura del proyecto
biblioteca_prueba_tecnica/
├── backend/
│   ├── Biblioteca.Api
│   └── Biblioteca.Api.Tests
└── frontend/
    └── biblioteca-frontend

🚀 Funcionalidades

🔍 Buscar libros usando OpenLibrary

📄 Mostrar resultados con título, autor, año y portada

❤️ Agregar libros a favoritos

⭐ Listar favoritos guardados

🗑️ Eliminar favoritos

🧪 Tests automatizados del backend

💾 Persistencia en SQLite

⚙️ Tecnologías usadas
Backend

.NET 10

ASP.NET Web API

Entity Framework Core

SQLite

Swagger

xUnit

Frontend

Angular

TypeScript

HTML

HttpClient

🖥️ Cómo ejecutar el proyecto
1️⃣ Backend

Desde:

/backend/Biblioteca.Api


Ejecutar:

dotnet restore
dotnet run


El backend queda disponible en:

http://localhost:5015


Swagger:

http://localhost:5015/swagger

2️⃣ Frontend

Desde:

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


Salida esperada:

Total: 5
Correctas: 5
Fallidas: 0

🗃️ Base de datos

Se usa SQLite

El archivo se crea automáticamente al iniciar el backend

No requiere configuración manual

🧠 Decisiones técnicas

Separé la arquitectura en:

Controllers

Services

Repositories

Usé inyección de dependencias

Implementé validaciones para evitar favoritos duplicados

El frontend consume solo mi API (no llama directo a OpenLibrary)

Agregué estado de carga (loading) para mejorar la UX

Manejo de errores HTTP en frontend y backend

🔁 Flujo de la aplicación

El frontend busca libros en mi API

Mi API consulta OpenLibrary

El frontend muestra los resultados

El usuario puede:

Agregar a favoritos

Ver favoritos

Eliminar favoritos

Todo se guarda en SQLite

🏁 Estado del proyecto

✅ Backend completo
✅ Frontend funcional
✅ Tests pasando
✅ Persistencia funcionando
✅ CRUD de favoritos completo

Se adjunto evidencias del proceso en carpeta evidencias

👤 Autor

Cristopher Ramírez