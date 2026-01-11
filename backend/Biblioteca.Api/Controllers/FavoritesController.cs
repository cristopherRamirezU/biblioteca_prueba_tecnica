using Biblioteca.Api.DTOs;
using Biblioteca.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;

        public FavoritesController(FavoritesService favoritesService)
        {
            _favoritesService = favoritesService;
        }

        // GET /api/favorites
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var favorites = await _favoritesService.GetFavoritesAsync();
            return Ok(favorites);
        }

        // POST /api/favorites
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddFavoriteRequestDto dto)
        {
            var result = await _favoritesService.AddFavoriteAsync(dto);

            if (!result.Ok)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(new { message = "Favorito agregado correctamente." });
        }

        // DELETE /api/favorites/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _favoritesService.DeleteFavoriteAsync(id);

            if (!result.Ok)
            {
                return NotFound(result.ErrorMessage);
            }

            return Ok(new { message = "Favorito eliminado correctamente." });
        }
    }
}
