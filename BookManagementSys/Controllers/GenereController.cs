using BookManagementSys.Models.Domain;
using BookManagementSys.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSys.Controllers
{

    public class GenereController : Controller
    {
        private readonly IGenerService _generService;
        public GenereController(IGenerService generService)
        {
            _generService = generService;
            
        }
        
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genere model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result= _generService.Add(model);
            if (result)
            {
                
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error Has Occured In ServerSide";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var record = _generService.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Genere model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _generService.Update(model);
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

            var result = _generService.Delete(id);
            
                
                return RedirectToAction("GetAll");
            
        }



        public IActionResult GetAll()
        {

            var data = _generService.GetAll();


            return View(data);

        }





    }
}
