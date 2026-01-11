using Biblioteca.Api.Data;
using Biblioteca.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Repositories
{
    public class FavoriteRepository
    {
        private readonly AppDbContext _context;

        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los favoritos de un usuario
        public async Task<List<Favorite>> GetByUserIdAsync(int userId)
        {
            return await _context.Favorites
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        // Buscar un favorito por usuario y ExternalId (para evitar duplicados)
        public async Task<Favorite?> GetByUserAndExternalIdAsync(int userId, string externalId)
        {
            return await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ExternalId == externalId);
        }

        // Buscar un favorito por Id
        public async Task<Favorite?> GetByIdAsync(int id)
        {
            return await _context.Favorites.FirstOrDefaultAsync(f => f.Id == id);
        }

        // Agregar un nuevo favorito
        public async Task AddAsync(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
        }

        // Eliminar un favorito
        public async Task DeleteAsync(Favorite favorite)
        {
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
        }
    }
}
