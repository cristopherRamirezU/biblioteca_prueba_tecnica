namespace Biblioteca.Api.ExternalClients
{
    public interface IOpenLibraryClient
    {
        Task<OpenLibrarySearchResponse?> SearchAsync(string query);
    }
}
