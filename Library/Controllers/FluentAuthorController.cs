using Library.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("Api/Controller")]
    public class FluentAuthorController : ControllerBase
    {
        private readonly LibraryContext _context;
        public FluentAuthorController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fluent_Author>>> Get()
        {
            return await _context.Fluent_Authors.ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<List<Fluent_Author>>> Post(Fluent_Author request)
        {
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();


            return await _context.Fluent_Authors.ToListAsync();

        }

    }
}
