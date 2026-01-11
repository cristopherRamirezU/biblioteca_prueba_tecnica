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

// Registrar DbContext para SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar HttpClient para llamadas a APIs externas
builder.Services.AddHttpClient();

// Registrar cliente de OpenLibrary
builder.Services.AddScoped<OpenLibraryClient>();

// Registrar servicio de búsqueda de libros
builder.Services.AddScoped<BookExternalService>();

// Registrar repositorio de favoritos
builder.Services.AddScoped<FavoriteRepository>();

// ✅ Registrar servicio de favoritos (ESTA ES LA LÍNEA QUE FALTABA)
builder.Services.AddScoped<FavoritesService>();

// Swagger / OpenAPI para documentar la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// =============================================
// Configurar el pipeline de solicitudes HTTP
// =============================================

if (app.Environment.IsDevelopment())
{
    // Habilitar Swagger en entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireccionar automáticamente a HTTPS
app.UseHttpsRedirection();

// Habilitar autorización (aunque todavía no usemos autenticación)
app.UseAuthorization();

// Mapear los controllers
app.MapControllers();

// Iniciar la aplicación
app.Run();
