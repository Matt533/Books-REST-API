using BookEStore.Domain_Layer.Models;
using System.ComponentModel.DataAnnotations;

namespace BookEStore.Domain_Layer.DTOs
{
    public record CreateAuthorDto
    {
        [MaxLength(40)]
        public required string Name { get; set; }
        public string ProfileImage  { get; set; } = string.Empty;
    }
}
