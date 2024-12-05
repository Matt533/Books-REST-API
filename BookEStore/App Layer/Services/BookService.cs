using BookEStore.Data_Layer.Repositories;
using BookEStore.Domain_Layer.DTOs;
using BookEStore.Domain_Layer.Models;
using BookEStore.Infrastructure_Layer.Exceptions;
using BookEStore.Infrastructure_Layer.Interfaces;

namespace BookEStore.App_Layer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository _bookRepository)
        {
            this.bookRepository = _bookRepository;
        }
        public async Task<List<Book>> GetAll()
        {
            var books = await bookRepository.GetAllAsync();
            return books;
        }

        public async Task<Book> GetById(Guid Id)
        {
            var book = await bookRepository.GetByIdAsync(Id);

            if(book is null)
            {
                throw new BookNotFoundException();
            }

            return book;
        }

        public async Task<Book> Create(Book bookModel)
        {
            return await bookRepository.CreateAsync(bookModel);
        }

        public async Task<Book> Update(UpdateBookDto updateBookDto, Guid Id)
        {
            var book =  await bookRepository.UpdateAsync(updateBookDto, Id);

            if (book is null)
            {
                throw new BookNotFoundException();
            }

            return book;
        }
        public async Task<Book> Delete(Guid Id)
        {
            var book = await bookRepository.DeleteAsync(Id);

            if (book is null)
            {
                throw new BookNotFoundException();
            }

            return book;
        }

    }
}
