using Azure.Core;
using Library.DbModels;
using Library.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    

    [ApiController]
    [Route("Api/Controller")]
    public class FluentBookController : ControllerBase
    {
        private readonly LibraryContext _context;
        public FluentBookController(LibraryContext context) 
        { 
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Fluent_Book>>> Get()
        {
            return await _context.Fluent_Books.ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<List<GetBookDto>>> Post(BookAddDto request)

            
        {
            Fluent_BookDetail detail = new()
            {
                PagesCount = request.PagesCount,
                Price = request.Price
            };

        Fluent_Book newBook = new()
        {
            Name = request.Name,
            AuthorId = request.AuthorId,
            PublisherId = request.PublisherId,
            BookDetail = detail,
            Description = request.Description
        };


            await _context.AddAsync(newBook);
            await _context.SaveChangesAsync();

            var booksObj = _context.Fluent_Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookDetail)
                .Select(b => new { b.Id, b.Name, b.BookDetail, b.Publisher, b.Author });

                List<GetBookDto>books = new List<GetBookDto>();

            foreach (var b in booksObj)
            {
                books.Add(new GetBookDto()
                {

                    Id = (int)b.Id,
                    Name = b.Name,
                    AuthorName = b.Author.FullName,
                    PagesCount = b.BookDetail.PagesCount,
                    PublisherName = b.Publisher.Name,
                });
            }

            return books;
        }

    }
}
