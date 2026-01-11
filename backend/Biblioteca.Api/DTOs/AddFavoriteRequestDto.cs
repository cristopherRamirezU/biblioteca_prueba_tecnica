namespace Biblioteca.Api.DTOs
{
    public class AddFavoriteRequestDto
    {
        public string ExternalId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Authors { get; set; } = null!;
        public int? FirstPublishYear { get; set; }
        public string? CoverUrl { get; set; }
    }
}
