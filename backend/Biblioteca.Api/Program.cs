using Biblioteca.Api.Data;
using Biblioteca.Api.ExternalClients;
using Biblioteca.Api.Services;
using Biblioteca.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// =============================================
// Agregar servicios al contenedor
// =============================================

// Agregar soporte para controllers
builder.Services.AddControllers();

// Configurar CORS para permitir llamadas desde Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Registrar DbContext para SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar HttpClient
builder.Services.AddHttpClient();

// =============================================
// REGISTRO CORRECTO DE DEPENDENCIAS
// =============================================

// Cliente externo OpenLibrary (INTERFAZ → IMPLEMENTACIÓN)
builder.Services.AddScoped<IOpenLibraryClient, OpenLibraryClient>();

// Repositorio de favoritos (INTERFAZ → IMPLEMENTACIÓN)
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();

// Servicios
builder.Services.AddScoped<BookExternalService>();
builder.Services.AddScoped<FavoritesService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// =============================================
// Configurar pipeline HTTP
// =============================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirección HTTPS
app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors("AllowAngular");

// Autorización
app.UseAuthorization();

// Mapear controllers
app.MapControllers();

// Iniciar app
app.Run();
