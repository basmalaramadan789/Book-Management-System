using BookManagementSys.Models.Domain;
using BookManagementSys.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSys.Controllers
{
    public class PublisherController : Controller
    {
       
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;

        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _publisherService.Add(model);
            if (result)
            {

                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error Has Occured In ServerSide";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var record = _publisherService.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _publisherService.Update(model);
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

            var result = _publisherService.Delete(id);


            return RedirectToAction("GetAll");

        }



        public IActionResult GetAll()
        {

            var data = _publisherService.GetAll();


            return View(data);

        }




    }
}
