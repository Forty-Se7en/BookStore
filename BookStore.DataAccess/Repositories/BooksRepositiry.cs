using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories
{
    public class BooksRepositiry : IBooksRepositiry
    {
        private readonly BookStoreDbContext _context;

        public BooksRepositiry(BookStoreDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var bookEntities = await _context.Books.AsNoTracking().ToListAsync();
            var books = bookEntities.Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book);
            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            //var bookEntity = await _context.Books.Where(b => b.Id == id).Select(b => { b.Id = id; b.Title = title; b.Description = description; b.Price = price; });
            await _context.Books.Where(b => b.Id == id).ExecuteUpdateAsync(s => s
            .SetProperty(b => b.Title, b => title)
            .SetProperty(b => b.Description, b => description)
            .SetProperty(b => b.Price, b => price));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books.Where(b => b.Id == id).ExecuteDeleteAsync();
            return id;
        }
    }
}
