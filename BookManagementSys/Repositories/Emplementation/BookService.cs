using BookManagementSys.Models.Domain;
using BookManagementSys.Repositories.Abstract;

namespace BookManagementSys.Repositories.Emplementation
{
    public class BookService:IBookService
    {
        private readonly ApplicationDbContext _context;
        public BookService(ApplicationDbContext context)
        {
            _context = context;

        }
        public bool Add(Book model)
        {
            try
            {
                _context.Books.Add(model);
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

        public Book FindById(int id)
        {
            var rr= _context.Books.Find(id);
            return (rr);

        }
        public IEnumerable<Book> GetAll()
        {
            var data = (from book in _context.Books
                        join auther in _context.Authers
                       on book.AuthorId equals auther.Id
                        join publisher in _context.Publishers on book.PublisherId equals publisher.Id
                        join genre in _context.Generes on book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            AuthorId = book.AuthorId,
                            GenreId = book.GenreId,
                            Ispn = book.Ispn,
                            PublisherId = book.PublisherId,
                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            GenreName = genre.GenreName,
                            AuthorName = auther.AutherName,
                            PublisherName = publisher.PublisherName,
                        }
                       ).ToList();
            return data;
        }

        public bool Update(Book model)
        {
            try
            {
                _context.Books.Update(model);
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
