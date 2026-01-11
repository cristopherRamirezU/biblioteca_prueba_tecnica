using Biblioteca.Api.DTOs;
using Biblioteca.Api.ExternalClients;

namespace Biblioteca.Api.Services
{
    public class BookExternalService
    {
        private readonly OpenLibraryClient _client;

        public BookExternalService(OpenLibraryClient client)
        {
            _client = client;
        }

        public async Task<List<BookSearchResultDto>> SearchBooksAsync(string query)
        {
            var response = await _client.SearchAsync(query);

            if (response == null || response.Docs == null)
                return new List<BookSearchResultDto>();

            var results = response.Docs.Take(20).Select(doc => new BookSearchResultDto
            {
                ExternalId = doc.Key ?? "",
                Title = doc.Title ?? "Sin título",
                Authors = doc.Author_name != null ? string.Join(", ", doc.Author_name) : "Desconocido",
                FirstPublishYear = doc.First_publish_year,
                CoverUrl = doc.Cover_i != null ? $"https://covers.openlibrary.org/b/id/{doc.Cover_i}-M.jpg" : null
            }).ToList();

            return results;
        }
    }
}
