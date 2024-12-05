using BookEStore.Domain_Layer.DTOs;
using BookEStore.Domain_Layer.Models;

namespace BookEStore.Infrastructure_Layer.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(Guid Id);
        Task<Book> Create(Book bookModel);
        Task<Book> Update(UpdateBookDto updateBookDto, Guid Id);
        Task<Book> Delete(Guid Id);
    }
}
