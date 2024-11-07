using BookStore.Core.Models;

namespace BookStore.Core.Abstractions
{
    public interface IBooksRepositiry
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<IEnumerable<Book>> GetAll();
        Task<Guid> Update(Guid id, string title, string description, decimal price);
    }
}