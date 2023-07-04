using Library.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("Api/Controller")]
    public class FluentReaderController : ControllerBase
    {
        private readonly LibraryContext _context;
        public FluentReaderController(LibraryContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fluent_Reader>>> Get()
        {
            return await _context.Fluent_Readers.ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<List<Fluent_Reader>>> Post(Fluent_Reader request)
        {
            await _context.Fluent_Readers.AddAsync(request);
            await _context.SaveChangesAsync();

            return await _context.Fluent_Readers.ToListAsync();

        }

    }
}
