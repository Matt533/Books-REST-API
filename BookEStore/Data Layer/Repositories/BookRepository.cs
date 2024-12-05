using BookEStore.Domain_Layer.DTOs;
using BookEStore.Domain_Layer.Models;
using BookEStore.Infrastructure_Layer.Exceptions;
using BookEStore.Infrastructure_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookEStore.Data_Layer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDataContext appDataContext;
        public BookRepository(AppDataContext _appDataContext)
        {
            this.appDataContext = _appDataContext;
        }
        public async Task<List<Book>> GetAllAsync()
        {
           var books = await appDataContext.books.Include(b => b.Author).ToListAsync();
            return books;
        }

        public async Task<Book?> GetByIdAsync(Guid Id)
        {
            var book = await appDataContext.books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == Id);
            return book;
        }

        public async Task<Book> CreateAsync(Book bookModel)
        {
            await appDataContext.books.AddAsync(bookModel);
            await appDataContext.SaveChangesAsync();
            return bookModel;
        }
        public async Task<Book?> UpdateAsync(UpdateBookDto updateBookDto, Guid Id)
        {
           var existingBook = await appDataContext.books.FirstOrDefaultAsync(b => b.Id == Id);

            if(existingBook is null)
            {
                return null;
            }

            existingBook.Title = updateBookDto.Title;
            existingBook.Price = updateBookDto.Price;
            existingBook.Description = updateBookDto.Description;
            existingBook.Language = updateBookDto.Language;
            existingBook.Genre = updateBookDto.Genre;
            existingBook.IsAvailable = updateBookDto.IsAvailable;
            existingBook.CoverImage = updateBookDto.CoverImage;
            existingBook.AuthorId = updateBookDto.AuthorId;

            await appDataContext.SaveChangesAsync();

            return existingBook;
        }
        public async Task<Book?> DeleteAsync(Guid Id)
        {
           var existingBook = await appDataContext.books.FirstOrDefaultAsync(b => b.Id == Id);

            if (existingBook is null) 
            {
                return null;
            }

            appDataContext.books.Remove(existingBook);
            await appDataContext.SaveChangesAsync();

            return existingBook;
        }

    }
}
