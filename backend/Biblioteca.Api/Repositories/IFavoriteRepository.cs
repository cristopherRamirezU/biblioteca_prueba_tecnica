using Biblioteca.Api.Models;

namespace Biblioteca.Api.Repositories
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> GetByUserIdAsync(int userId);
        Task<Favorite?> GetByUserAndExternalIdAsync(int userId, string externalId);
        Task<Favorite?> GetByIdAsync(int id);
        Task AddAsync(Favorite favorite);
        Task DeleteAsync(Favorite favorite);
    }
}
