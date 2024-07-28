using BookManagementSys.Models.Domain;

namespace BookManagementSys.Repositories.Abstract
{
    public interface IAuthorService
    {
        bool Add(Auther model);
        bool Delete(int id);
        Auther FindById(int id);
        bool Update(Auther model);
        IEnumerable<Auther> GetAll();
    }
}
