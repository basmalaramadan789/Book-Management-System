using BookManagementSys.Models.Domain;
using BookManagementSys.Repositories.Abstract;

namespace BookManagementSys.Repositories.Interfaces
{
    public class GenereService : IGenerService

    {
        private readonly ApplicationDbContext _context;
        public GenereService(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public bool Add(Genere model)
        {
            try
            {
                _context.Generes.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var data = this.FindById(id);
            try 
            {
                if (data == null)
                    return false;
                _context.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Genere FindById(int id)
        {
            return _context.Generes.Find(id);

        }
        public IEnumerable<Genere> GetAll()
        {
            return _context.Generes.ToList();
        }

        public bool Update(Genere model)
        {
            try
            {
                _context.Generes.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
