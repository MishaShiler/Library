using System.ComponentModel.DataAnnotations.Schema;
using Library.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Library.DbModels
{
    public class Fluent_Reader
    {
        //[Key]

        public int Id { get; set; }
        //[Required]
        //[MaxLength(100)]
        public string FirstName { get; set; }
        //[Required]
        //[MaxLength(100)]
        public string LastName { get; set; }
       //[Column("Phone")]
        //[MaxLength(20)]
        public string PhoneNumber { get ; set; }
        //[NotMapped]
        public int TempId { get; set; }
        //List<Book> Book { get; set; }
        public List<Fluent_BookReader> BookReaders { get; set; }

    }


public static class Fluent_ReaderEndpoints
{
	public static void MapFluent_ReaderEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Fluent_Reader").WithTags(nameof(Fluent_Reader));

        group.MapGet("/", async (LibraryContext db) =>
        {
            return await db.Fluent_Readers.ToListAsync();
        })
        .WithName("GetAllFluent_Readers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Fluent_Reader>, NotFound>> (int id, LibraryContext db) =>
        {
            return await db.Fluent_Readers.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Fluent_Reader model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetFluent_ReaderById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Fluent_Reader fluent_Reader, LibraryContext db) =>
        {
            var affected = await db.Fluent_Readers
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, fluent_Reader.Id)
                  .SetProperty(m => m.FirstName, fluent_Reader.FirstName)
                  .SetProperty(m => m.LastName, fluent_Reader.LastName)
                  .SetProperty(m => m.PhoneNumber, fluent_Reader.PhoneNumber)
                  .SetProperty(m => m.TempId, fluent_Reader.TempId)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateFluent_Reader")
        .WithOpenApi();

        group.MapPost("/", async (Fluent_Reader fluent_Reader, LibraryContext db) =>
        {
            db.Fluent_Readers.Add(fluent_Reader);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Fluent_Reader/{fluent_Reader.Id}",fluent_Reader);
        })
        .WithName("CreateFluent_Reader")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, LibraryContext db) =>
        {
            var affected = await db.Fluent_Readers
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteFluent_Reader")
        .WithOpenApi();
    }
}}
