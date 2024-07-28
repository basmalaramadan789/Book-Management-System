using BookManagementSys.Models.Domain;
using BookManagementSys.Repositories.Abstract;
using BookManagementSys.Repositories.Emplementation;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSys.Controllers
{
    public class AutherController : Controller
    {

        private readonly IAuthorService _AuthorService;
        public AutherController(IAuthorService AuthorService)
        {
            _AuthorService = AuthorService;

        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Auther model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _AuthorService.Add(model);
            if (result)
            {

                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error Has Occured In ServerSide";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var record = _AuthorService.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Auther model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _AuthorService.Update(model);
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

            var result = _AuthorService.Delete(id);


            return RedirectToAction("GetAll");

        }



        public IActionResult GetAll()
        {

            var data = _AuthorService.GetAll();


            return View(data);

        }




    }
}
