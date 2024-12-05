using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookEStore.Domain_Layer.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        [MaxLength(40)]
        public required string Name { get; set; }
        public string ProfileImage { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
