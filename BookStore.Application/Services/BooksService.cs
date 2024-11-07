using BookStore.Core.Abstractions;
using BookStore.Core.Models;

namespace BookStore.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepositiry _bookRepository;

        public BooksService(IBooksRepositiry bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _bookRepository.Create(book);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _bookRepository.Delete(id);
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
        {
            return await _bookRepository.Update(id, title, description, price);
        }
    }
}
