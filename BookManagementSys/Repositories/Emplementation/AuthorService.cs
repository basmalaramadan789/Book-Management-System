using BookManagementSys.Models.Domain;
using BookManagementSys.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSys.Repositories.Emplementation
{
    public class AuthorService:IAuthorService
    {
        private readonly ApplicationDbContext _context;
        public AuthorService(ApplicationDbContext context)
        {
            _context = context;

        }
        public bool Add(Auther model)
        {
            try
            {
                _context.Authers.Add(model);
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
            catch (Exception ex)
            {
                return false;
            }
        }

        public Auther FindById(int id)
        {
            return _context.Authers.Find(id);

        }
        public IEnumerable<Auther> GetAll()
        {
            return _context.Authers.ToList();
        }

        public bool Update(Auther model)
        {
            try
            {
                _context.Authers.Update(model);
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
