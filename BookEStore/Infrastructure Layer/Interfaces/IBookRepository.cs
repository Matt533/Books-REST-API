using BookEStore.Domain_Layer.DTOs;
using BookEStore.Domain_Layer.Models;

namespace BookEStore.Infrastructure_Layer.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(Guid Id);
        Task<Book>  CreateAsync(Book bookModel);
        Task<Book?> UpdateAsync(UpdateBookDto updateBookDto,Guid Id);
        Task<Book?> DeleteAsync(Guid Id);
    }
}
