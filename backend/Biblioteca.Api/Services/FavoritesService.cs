using Biblioteca.Api.DTOs;
using Biblioteca.Api.Models;
using Biblioteca.Api.Repositories;

namespace Biblioteca.Api.Services
{
    public class FavoritesService
    {
        private readonly FavoriteRepository _repository;

        // Para simplificar, usamos siempre el mismo usuario
        private const int DefaultUserId = 1;

        public FavoritesService(FavoriteRepository repository)
        {
            _repository = repository;
        }

        // Obtener todos los favoritos del usuario
        public async Task<List<Favorite>> GetFavoritesAsync()
        {
            return await _repository.GetByUserIdAsync(DefaultUserId);
        }

        // Agregar un nuevo favorito
        public async Task<(bool Ok, string ErrorMessage)> AddFavoriteAsync(AddFavoriteRequestDto dto)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(dto.ExternalId) ||
                string.IsNullOrWhiteSpace(dto.Title) ||
                string.IsNullOrWhiteSpace(dto.Authors))
            {
                return (false, "Faltan campos obligatorios.");
            }

            // Verificar si ya existe (evitar duplicados)
            var existing = await _repository.GetByUserAndExternalIdAsync(DefaultUserId, dto.ExternalId);
            if (existing != null)
            {
                return (false, "Este libro ya está agregado a favoritos.");
            }

            var favorite = new Favorite
            {
                UserId = DefaultUserId,
                ExternalId = dto.ExternalId,
                Title = dto.Title,
                Authors = dto.Authors,
                FirstPublishYear = dto.FirstPublishYear,
                CoverUrl = dto.CoverUrl
            };

            await _repository.AddAsync(favorite);
            return (true, string.Empty);
        }

        // Eliminar un favorito por Id
        public async Task<(bool Ok, string ErrorMessage)> DeleteFavoriteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return (false, "El favorito no existe.");
            }

            await _repository.DeleteAsync(existing);
            return (true, string.Empty);
        }
    }
}
