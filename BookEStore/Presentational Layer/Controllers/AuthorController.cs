using BookEStore.App_Layer.Services;
using BookEStore.Domain_Layer.DTOs;
using BookEStore.Domain_Layer.Models;
using BookEStore.Infrastructure_Layer.Interfaces;
using BookEStore.Infrastructure_Layer.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BookEStore.Presentational_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;
        public AuthorController(IAuthorService _authorService)
        {
            this.authorService = _authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors() 
        {
            var authors = await authorService.GetAllAsync();

            var authorsDto = authors.Select(a => a.ToAuthorDto()).ToList();

            return Ok(authorsDto);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {

            var existingAuthor = await authorService.GetByIdAsync(Id);

            var authorDto = existingAuthor.ToAuthorDto();
            
            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto createAuthorDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorModel = createAuthorDto.FromCreateAuthorDtoToAuthor();

            var newAuthor = await authorService.CreateAsync(authorModel);

            return CreatedAtAction(nameof(GetById), 
                                    new {id = newAuthor.Id}, 
                                        newAuthor.ToAuthorDto());  
        }

        [HttpPatch]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDto updateAuthorDto, [FromRoute] Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var updatedAuthor =  await authorService.UpdateAsync(updateAuthorDto,Id);

            return Ok(updatedAuthor.ToAuthorDto());
        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await authorService.DeleteAsync(Id);
            return NoContent();
        }
    }

}
