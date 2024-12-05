using BookEStore.Domain_Layer.DTOs;
using BookEStore.Domain_Layer.Models;

namespace BookEStore.Infrastructure_Layer.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(Guid id);
        Task<Author> CreateAsync(Author authorModel);
        Task<Author> UpdateAsync(UpdateAuthorDto updateAuthorDto, Guid Id);
        Task<Author> DeleteAsync(Guid Id);
        Task<bool> AuthorExistsAsync(Guid Id);
    }
}
