using Library.DbModels;
using Library.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.Xml;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FluentBookReaderController : ControllerBase

    {
        private readonly LibraryContext _context;

        public FluentBookReaderController(LibraryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Fluent_BookReader>>> Post(AddBookReaderADto request)
        {
            var bookReader = new Fluent_BookReader()
            {
                BookId = request.Bookid,
                ReaderId = request.ReaderId

            };
            await _context.AddAsync(bookReader);
            await _context.SaveChangesAsync();

            //var bookReadersNew = _context.Fluent_Books
            //    .Include(b => b.BookReaders)
            //    .ThenInclude(br => br.Reader)
            //    .Select(b => new
            //    {
            //        b.Name,
            //        b.Description,
            //        b.BookReaders.First(x=>x.)
            //    });

            var bookReaders = _context.Fluent_BookReaders
                .Include(x => x.Book)
                .Include(x => x.Reader)
                .Select(br => new
                {
                    Fluent_Book = new

                    {
                        br.Book.Id,
                        br.Book.Name,
                        br.Book.Description
                    }



                     BookDetail = new

                     {
                         br.Book.BookDetail.Id,
                         br.Book.BookDetail.PagesCount,
                         br.Book.bookDetail.Price
                     }
                

            //Fluent_Book = new
            //    {
            //    .Include(x => x.Book)
            //    .Include(x => x.Reader)
            //    .Select(br => new { br.Book, br.Reader })
            //    };

            Fluent_Reader = new
            {
                br.Reader.Id,
                br.Reader.FirstName,
                br.Reader.LastName,
                br.Reader.PhoneNumber
            }
            }).ToList();

            //Fluent_Book = new

            //{
            //    br.Book.Id,
            //    br.Book.Name,
            //    br.Book.Description
            //};

            //Fluent_BookDetail = new

            //{
            //    br.Book.BookDetail.Id,
            //    br.Book.BookDetail.PagesCount,
            //    br.Book.bookDetail.Price
            //};

            //Reader = new
            //{
            //    br.Reader.Id,
            //    br.Reader.FirstName,
            //    br.Reader.LastName,
            //    br.Reader.PhoneNumber
            //}).ToList();
             

            return Result;

              private readonly LibraryContext _context;
        public FluentBookReaderController(LibraryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Fluent_BookReader>>> Get()
        {
            var result = from br in _context.Fluent_BookReaders
                         join book in _context.Fluent_Books on br.BookId equals book.Id
                         join reader in _context.Fluent_Readers on br.ReaderId equals reader.Id;
                         select new { book, reader };

            return Ok(result);
        }

        [Route("Search{ReaderName, BookReader}")]
        [HttpGet]
        public async Task<ActionResult<List<Fluent_BookReader>>> Get(string ReaderName, string BookReader)
        {
            //var result = from br in _context.Fluent_BookReaders
            //             join book in _context.Fluent_Books on br.BookId equals book.Id
            //             join reader in _context.Fluent_Readers on br.ReaderId equals reader.Id

            //             where
            //             (string.IsNullOrEmpty(BookName) || book.Name.Contains(BookName))
            //             &&
            //             (string.IsNullOrEmpty(ReaderName) || reader.FirstName.Contains(ReaderName))

            //             select new { book, reader };

            //return Ok(result);

            //select now { book, reader };

            //var bookReaders = _context.Fluent_BookReaders
            //     .Include(x => x.Book)
            //     .Include(x => x.Reader);

            //if (!string.IsNullOrEmpty(BookName))
            //{
            //    var querry2 = bookReaders.Where(x => x.Book.Name == BookName).ToList();
            //}

            //var result = _context.Fluent_BookReaders;

            //     if (!string.IsNullOrEmpty(BookName))
            //{
            //        results = results.Where(x => x.Nook.Name == BookName);
            //}



            //.Select(br => new
            //{
            //    br.Book, br.Reader

            //}).ToList();

            // var results = _context.BookReaders
            //.Where(x => x.Reader.FirstName == "Giotgi");
            // results = results.Where(x => x.Reader.LastName == "Bigvava");
            // var finalResult = results.Select(x=> new
            // {
            //     x.Reder,
            //     x.Book
            // })

            //var Querry = _context.Fluent_BookReaders
            //    .Include(x => x.Reader)
            //    .Include(x => x.Book)
            //    .Select(br=> new {br.Reader, br.Book});

            var querry = from br in _context.Fluent_BookReaders
                         join book in _context.Fluent_Books on br.BookId equals book.Id
                         join reader in _context.Fluent_Readers on br.ReaderId equals reader.Id
                         select new { book, reader };

            if (!string.IsNullOrEmpty(ReaderName))
            {
                querry = querry.Where(x=>x.Reader.FirstName.Contains(ReaderName));
            }

            if (!string.IsNullOrEmpty(BookName))
            {
                querry = querry.Where(x => x.Book.Name.Contains(BookName));
            }


            return Ok(Querry);
        }

    }

    }
}
