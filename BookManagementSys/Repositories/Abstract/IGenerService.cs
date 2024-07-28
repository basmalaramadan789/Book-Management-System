using BookManagementSys.Models.Domain;

namespace BookManagementSys.Repositories.Abstract
{
    public interface IGenerService
    {
        bool Add(Genere model);
        bool Delete(int id);
        Genere FindById(int id);
        bool Update(Genere model);
        IEnumerable<Genere> GetAll();
    }
}
