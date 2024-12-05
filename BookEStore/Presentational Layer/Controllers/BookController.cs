using BookEStore.App_Layer.Services;
using BookEStore.Domain_Layer.DTOs;
using BookEStore.Infrastructure_Layer.Exceptions;
using BookEStore.Infrastructure_Layer.Interfaces;
using BookEStore.Infrastructure_Layer.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BookEStore.Presentational_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        public BookController(IBookService _bookService, IAuthorService _authorService)
        {
            this.bookService = _bookService;
            this.authorService = _authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookService.GetAll();

            var booksDtos = books.Select(s => s.ToBookDto()).ToList();

            return Ok(booksDtos);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetBookById([FromRoute] Guid Id)
        {
            var existingBook = await bookService.GetById(Id);

            return Ok(existingBook.ToBookDto()); 
        }   

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto createBookDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine(error); // Или користи log да ги испечатиш
                }
                return BadRequest(ModelState);
            }

            var existingAuthor = await authorService.AuthorExistsAsync(createBookDto.AuthorId);

            if(existingAuthor is false)
            {
                return NotFound("Author doesn't exist!");
            }

            var newBookModel = createBookDto.FromCreateBookDtoToBook();

            await bookService.Create(newBookModel);

            return CreatedAtAction(nameof(GetBookById), 
                                    new { id = newBookModel.Id }, 
                                        newBookModel.ToBookDto());
        }

        [HttpPut]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid Id, [FromBody] UpdateBookDto updateBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAuthor = await authorService.AuthorExistsAsync(updateBookDto.AuthorId);

            if (existingAuthor is false)
            {
                return NotFound("Author doesn't exist!");
            }

            var updatedBook =  await bookService.Update(updateBookDto,Id);

            return Ok(updatedBook.ToBookDto());
        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid Id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await bookService.Delete(Id);

            return NoContent();
        }
    }
}
