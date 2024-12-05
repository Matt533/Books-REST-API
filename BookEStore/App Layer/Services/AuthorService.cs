using BookEStore.Data_Layer.Repositories;
using BookEStore.Domain_Layer.DTOs;
using BookEStore.Domain_Layer.Models;
using BookEStore.Infrastructure_Layer.Exceptions;
using BookEStore.Infrastructure_Layer.Interfaces;

namespace BookEStore.App_Layer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorService(IAuthorRepository _authorRepository)
        {
            this.authorRepository = _authorRepository;
        }
        public async Task<List<Author>> GetAllAsync()
        {
            return await authorRepository.GetAllAsync();            
        }
        public async Task<Author> GetByIdAsync(Guid id)
        {
            var author = await authorRepository.GetByIdAsync(id);

            if(author is null)
            {
                throw new AuthorNotFoundException();
            }

            return author;
        }

        public async Task<Author> CreateAsync(Author authorModel)
        {
            return await authorRepository.CreateAsync(authorModel);
        }
        public async Task<Author> UpdateAsync(UpdateAuthorDto updateAuthorDto, Guid Id)
        {
           var author = await authorRepository.UpdateAsync(updateAuthorDto, Id);

            if (author is null)
            {
                throw new AuthorNotFoundException();
            }

            return author;

        }
        
        public async Task<Author> DeleteAsync(Guid Id)
        {
            var author = await authorRepository.DeleteAsync(Id);

            if (author is null)
            {
                throw new AuthorNotFoundException();
            }

            return author;
        }
        public async Task<bool> AuthorExistsAsync(Guid AuthorId)
        {
            return await authorRepository.AuthorExists(AuthorId);
        }

    }
}
