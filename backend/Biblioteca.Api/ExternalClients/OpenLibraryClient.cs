using System.Net.Http.Json;

namespace Biblioteca.Api.ExternalClients
{
    public class OpenLibraryClient
    {
        private readonly HttpClient _httpClient;

        public OpenLibraryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OpenLibrarySearchResponse?> SearchAsync(string query)
        {
            var url = $"https://openlibrary.org/search.json?q={Uri.EscapeDataString(query)}";
            return await _httpClient.GetFromJsonAsync<OpenLibrarySearchResponse>(url);
        }
    }

    // Clases internas para mapear la respuesta de OpenLibrary
    public class OpenLibrarySearchResponse
    {
        public List<OpenLibraryDoc> Docs { get; set; } = new();
    }

    public class OpenLibraryDoc
    {
        public string? Key { get; set; }
        public string? Title { get; set; }
        public List<string>? Author_name { get; set; }
        public int? First_publish_year { get; set; }
        public int? Cover_i { get; set; }
    }
}
