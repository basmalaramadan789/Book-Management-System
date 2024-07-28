using BookManagementSys.Models.Domain;

namespace BookManagementSys.Repositories.Abstract
{
    public interface IPublisherService
    {
        bool Add(Publisher model);
        bool Delete(int id);
        Publisher FindById(int id);
        bool Update(Publisher model);
        IEnumerable<Publisher> GetAll();
    }
}
