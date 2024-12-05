using BookEStore.Domain_Layer.Models;
using System.ComponentModel.DataAnnotations;

namespace BookEStore.Domain_Layer.DTOs
{
    public record AuthorDto
    {
        public Guid Id { get; set; }
        [MaxLength(40)]
        public required string Name { get; set; }
        public string  ProfileImage { get; set; } = string.Empty;
        public List<Book> Books { get; set; }
    }
}
