using BookEStore.Domain_Layer.DTOs;
using BookEStore.Domain_Layer.Models;

namespace BookEStore.Infrastructure_Layer.Mappers
{
    public static class BookMapper
    {
        public static Book FromCreateBookDtoToBook(this CreateBookDto createBookDto)
        {
            return new Book
            {
                Id = Guid.NewGuid(),
                Title = createBookDto.Title,
                Price = createBookDto.Price,
                Description = createBookDto.Description,
                Language = createBookDto.Language,
                Genre = createBookDto.Genre,
                IsAvailable = createBookDto.IsAvailable,
                CoverImage = createBookDto.CoverImage,
                AuthorId = createBookDto.AuthorId,
            };
        }

        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Price = bookModel.Price,
                Description = bookModel.Description,
                Language = bookModel.Language,
                Genre = bookModel.Genre,
                IsAvailable = bookModel.IsAvailable,
                CoverImage =    bookModel.CoverImage,
                AuthorId = bookModel.AuthorId,
                Author = bookModel.Author
            };
        }

    }
}
