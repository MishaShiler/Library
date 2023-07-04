using Library.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("Api/Controller")]
    public class FluentPublisherController : ControllerBase
    {
        private readonly LibraryContext _context;
        public FluentPublisherController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fluent_Publisher>>> Get()
        {
            return await _context.Fluent_Publishers.ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<List<Fluent_Publisher>>> Post(Fluent_Publisher request)
        {
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();


            return await _context.Fluent_Publishers.ToListAsync();

        }

    }
}
