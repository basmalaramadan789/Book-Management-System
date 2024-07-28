using BookManagementSys.Models.Domain;
using BookManagementSys.Repositories.Abstract;
using BookManagementSys.Repositories.Emplementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookManagementSys.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenerService _generService;
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IGenerService generService, IPublisherService publisherService, IAuthorService authorService)
        {
            _bookService = bookService;
            _generService = generService;
            _publisherService = publisherService;
            _authorService = authorService;
            

        }
        

        public IActionResult Add()
        {
            var model=new Book();
            model.AutherList=_authorService.GetAll().Select(a=> new SelectListItem{Text=a.AutherName,Value=a.Id.ToString()}).ToList();
            model.PublisherList=_publisherService.GetAll().Select(a=> new SelectListItem{Text=a.PublisherName,Value=a.Id.ToString()}).ToList();
            model.GenreList=_generService.GetAll().Select(a=> new SelectListItem{Text=a.GenreName,Value=a.Id.ToString()}).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.AutherList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AutherName, Value = a.Id.ToString(),Selected=a.Id==model.AuthorId}).ToList();
            model.PublisherList = _publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = _generService.GetAll().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _bookService.Add(model);
            if (result)
            {

                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error Has Occured In ServerSide";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var model = _bookService.FindById(id);
            model.AutherList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AutherName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = _publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = _generService.GetAll().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AutherList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AutherName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = _publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = _generService.GetAll().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _bookService.Update(model);
            if (result)
            {
                TempData["msg"] = "Updated Successfully";
                return RedirectToAction(nameof(Update));
            }
            TempData["msg"] = "Error Has Occured In ServerSide";
            return View(model);
        }

        public IActionResult Delete(int id)
        {

            var result = _bookService.Delete(id);


            return RedirectToAction("GetAll");

        }



        public IActionResult GetAll()
        {

            var data = _bookService.GetAll();


            return View(data);

        }



    }
}
