using BookManagementSys.Models.Domain;

namespace BookManagementSys.Repositories.Abstract
{
    public interface IBookService
    {
        bool Add(Book model);
        bool Delete(int id);
        Book FindById(int id);
        bool Update(Book model);
        IEnumerable<Book> GetAll();
    }
}
