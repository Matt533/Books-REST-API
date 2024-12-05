using BookEStore.Domain_Layer.DTOs;
using BookEStore.Domain_Layer.Models;

namespace BookEStore.Infrastructure_Layer.Mappers
{
    public static class AuthorsMapper
    {
        public static Author FromCreateAuthorDtoToAuthor(this CreateAuthorDto createAuthorDto)
        {
            return new Author
            {
                Id = Guid.NewGuid(),
                Name = createAuthorDto.Name,
                ProfileImage =  createAuthorDto.ProfileImage
            };
        }

        public static AuthorDto ToAuthorDto(this Author authorModel)
        {
            return new AuthorDto
            {
                Id = authorModel.Id,
                Name = authorModel.Name,
                ProfileImage = authorModel.ProfileImage,
                Books = authorModel.Books,
            };
        }
        
    }
}
