using Biblioteca.Api.DTOs;
using Biblioteca.Api.Models;
using Biblioteca.Api.Repositories;
using Biblioteca.Api.Services;
using Moq;
using Xunit;

namespace Biblioteca.Api.Tests
{
    public class FavoritesServiceTests
    {
        private readonly Mock<IFavoriteRepository> _repositoryMock;
        private readonly FavoritesService _service;

        public FavoritesServiceTests()
        {
            _repositoryMock = new Mock<IFavoriteRepository>();
            _service = new FavoritesService(_repositoryMock.Object);
        }

        [Fact]
        public async Task No_debe_permitir_duplicados()
        {
            // Arrange
            var dto = new AddFavoriteRequestDto
            {
                ExternalId = "X1",
                Title = "Libro",
                Authors = "Autor"
            };

            _repositoryMock
                .Setup(r => r.GetByUserAndExternalIdAsync(1, "X1"))
                .ReturnsAsync(new Favorite());

            // Act
            var result = await _service.AddFavoriteAsync(dto);

            // Assert
            Assert.False(result.Ok);
        }

        [Fact]
        public async Task No_debe_permitir_request_invalido()
        {
            // Arrange
            var dto = new AddFavoriteRequestDto
            {
                ExternalId = "",
                Title = "",
                Authors = ""
            };

            // Act
            var result = await _service.AddFavoriteAsync(dto);

            // Assert
            Assert.False(result.Ok);
        }

        [Fact]
        public async Task Debe_agregar_favorito_correctamente()
        {
            // Arrange
            var dto = new AddFavoriteRequestDto
            {
                ExternalId = "X2",
                Title = "Libro OK",
                Authors = "Autor"
            };

            _repositoryMock
                .Setup(r => r.GetByUserAndExternalIdAsync(1, "X2"))
                .ReturnsAsync((Favorite?)null);

            // Act
            var result = await _service.AddFavoriteAsync(dto);

            // Assert
            Assert.True(result.Ok);
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Favorite>()), Times.Once);
        }

        [Fact]
        public async Task Eliminar_favorito_inexistente_debe_fallar()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetByIdAsync(99))
                .ReturnsAsync((Favorite?)null);

            // Act
            var result = await _service.DeleteFavoriteAsync(99);

            // Assert
            Assert.False(result.Ok);
        }
    }
}
