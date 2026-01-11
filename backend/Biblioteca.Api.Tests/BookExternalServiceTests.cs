using Biblioteca.Api.ExternalClients;
using Biblioteca.Api.Services;
using Moq;
using Xunit;

namespace Biblioteca.Api.Tests
{
    public class BookExternalServiceTests
    {
        [Fact]
        public async Task Debe_mapear_respuesta_de_api_externa_a_dto()
        {
            // Arrange
            var fakeResponse = new OpenLibrarySearchResponse
            {
                Docs = new List<OpenLibraryDoc>
                {
                    new OpenLibraryDoc
                    {
                        Key = "ID1",
                        Title = "Libro Test",
                        Author_name = new List<string> { "Autor 1" },
                        First_publish_year = 2000,
                        Cover_i = 123
                    }
                }
            };

            var clientMock = new Mock<IOpenLibraryClient>();
            clientMock
                .Setup(c => c.SearchAsync("test"))
                .ReturnsAsync(fakeResponse);

            var service = new BookExternalService(clientMock.Object);

            // Act
            var result = await service.SearchBooksAsync("test");

            // Assert
            Assert.Single(result);
            Assert.Equal("ID1", result[0].ExternalId);
            Assert.Equal("Libro Test", result[0].Title);
            Assert.Equal("Autor 1", result[0].Authors);
        }
    }
}
