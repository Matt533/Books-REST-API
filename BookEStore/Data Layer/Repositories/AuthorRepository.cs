
using BookEStore.Domain_Layer.DTOs;
using BookEStore.Domain_Layer.Models;
using BookEStore.Infrastructure_Layer.Exceptions;
using BookEStore.Infrastructure_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BookEStore.Data_Layer.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDataContext appDataContext;
        public AuthorRepository(AppDataContext _appDataContext)
        {
            this.appDataContext = _appDataContext;
        }
        public async Task<List<Author>> GetAllAsync()
        {
            var authors = await appDataContext.authors.Include(b => b.Books).ToListAsync();
            return authors;
        }

        public async Task<Author?> GetByIdAsync(Guid id)
        {
           var existingAuthor = await appDataContext.authors.Include(b => b.Books).FirstOrDefaultAsync(a => a.Id == id);

            if(existingAuthor is null)
            {
                return null;
            }

            return existingAuthor;
        }

        public async Task<Author> CreateAsync(Author authorModel)
        {
            await appDataContext.authors.AddAsync(authorModel);
            await appDataContext.SaveChangesAsync();

            return authorModel;
        }
        public async Task<Author?> UpdateAsync(UpdateAuthorDto updateAuthorDto, Guid Id)
        {
            var existingAuthor = await appDataContext.authors.FirstOrDefaultAsync(a => a.Id == Id);

            if (existingAuthor is null)
            {
                return null;
            }

            existingAuthor.Id = Id;
            existingAuthor.Name = updateAuthorDto.Name;
            existingAuthor.ProfileImage = updateAuthorDto.ProfileImage;

            await appDataContext.SaveChangesAsync();    

            return existingAuthor;
        }
        public async Task<Author?> DeleteAsync(Guid Id)
        {
            var existingAuthor = await appDataContext.authors.FirstOrDefaultAsync(a => a.Id == Id);

            if (existingAuthor is null)
            {
                return null;
            }

            appDataContext.authors.Remove(existingAuthor);
            await appDataContext.SaveChangesAsync();

            return existingAuthor;
        }

        public async Task<bool> AuthorExists(Guid Id)
        {
            var existingAuthor = await appDataContext.authors.FirstOrDefaultAsync(a => a.Id == Id);
            
            if(existingAuthor is null)
            {
                return false;
            }

            return true;
        }
    }
}
