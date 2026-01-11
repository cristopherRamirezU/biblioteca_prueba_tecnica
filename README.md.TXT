Prueba Técnica - Biblioteca (VISTA TI)

Proyecto de prueba técnica para el cargo de Desarrollador Junior en VISTA TI.

DESCRIPCIÓN

Aplicación web que permite:

Buscar libros utilizando una API pública (OpenLibrary).

Guardar libros como favoritos en una base de datos SQL Server.

Listar y eliminar favoritos.

Actualmente el proyecto incluye solamente el backend funcional.

ESTRUCTURA DEL PROYECTO

/backend API REST en .NET
/frontend Frontend en Angular (pendiente)
/database Scripts SQL para crear la base de datos

BASE DE DATOS

En la carpeta /database se incluye el script:

create_db.sql

Este script:

Crea la base de datos BibliotecaDb

Crea las tablas Users y Favorites

Agrega una restricción única para evitar duplicados

Inserta un usuario inicial de prueba

Cómo ejecutar el script:

Abrir SQL Server Management Studio

Abrir el archivo create_db.sql

Ejecutarlo con el botón Execute

BACKEND (.NET)

Requisitos:

.NET SDK 8

SQL Server (Express o Developer)

Cómo ejecutar el backend:

Desde la carpeta:

/backend/Biblioteca.Api

Ejecutar:

dotnet run

La API queda disponible en:

http://localhost:5015

Swagger:

http://localhost:5015/swagger

ENDPOINTS DISPONIBLES

Buscar libros:

GET /api/books/search?query=harry

Consulta la API pública OpenLibrary

Devuelve una lista normalizada de libros

FAVORITOS

Listar favoritos:

GET /api/favorites

Agregar favorito:

POST /api/favorites

Body de ejemplo:

{
"externalId": "/works/OL82563W",
"title": "Harry Potter and the Philosopher's Stone",
"authors": "J. K. Rowling",
"firstPublishYear": 1997,
"coverUrl": null
}

Eliminar favorito:

DELETE /api/favorites/{id}

ARQUITECTURA DEL BACKEND

El backend utiliza una arquitectura en capas:

Controllers

Services

Repositories

ExternalClients

DTOs

Models

Data (DbContext)

ESTADO DEL PROYECTO

Backend completo y funcional

Base de datos lista con script SQL

Frontend pendiente

Tests unitarios pendientes

DECISIONES TÉCNICAS

Se utiliza SQL Server como base de datos relacional.

Se utiliza Entity Framework Core para acceso a datos.

El backend consume directamente la API externa OpenLibrary.

Para simplificar, se utiliza un usuario fijo con Id = 1.