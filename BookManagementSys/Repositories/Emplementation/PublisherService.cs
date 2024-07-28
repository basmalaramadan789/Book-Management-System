using BookManagementSys.Models.Domain;
using BookManagementSys.Repositories.Abstract;

namespace BookManagementSys.Repositories.Emplementation
{
    public class PublisherService: IPublisherService
    {
        private readonly ApplicationDbContext _context;
        public PublisherService(ApplicationDbContext context)
        {
            _context = context;

        }
        public bool Add(Publisher model)
        {
            try
            {
                _context.Publishers.Add(model);
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

        public Publisher FindById(int id)
        {
            return _context.Publishers.Find(id);

        }
        public IEnumerable<Publisher> GetAll()
        {
            return _context.Publishers.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                _context.Publishers.Update(model);
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
