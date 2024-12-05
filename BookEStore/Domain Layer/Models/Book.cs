using System.ComponentModel.DataAnnotations;

namespace BookEStore.Domain_Layer.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        [MaxLength(40)]
        public required string Title { get; set; }
        public required decimal Price { get; set; }
        [MaxLength(200)]
        public required string Description { get; set; }
        public required string Language { get; set; }
        [MaxLength (50)]
        public required string Genre { get; set; }
        public bool IsAvailable { get; set; }
        public string CoverImage { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
