using Microsoft.AspNetCore.Mvc;
using BookAppSolution.DataAccess;
using BookAppSolution.Models;
using BookAppSolution.DataAccess.Repository.IRepository;

namespace BookApp.Areas.Admin.Controllers
{

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = unitOfWork.Category.GetAll();

            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customer Error", "The Display Order cannot exactly make the Name");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.Category.Add(obj);
                unitOfWork.Save();

                TempData["success"] = "Catergory Created Successfully";

                return RedirectToAction("Index");
            }
            return View(obj);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customer Error", "The Display Order cannot exactly make the Name");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.Category.Update(obj);
                unitOfWork.Save();

                TempData["success"] = "Catergory Edited Successfully";

                return RedirectToAction("Index");
            }


            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDbFirst = unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            unitOfWork.Category.Remove(obj);
            unitOfWork.Save();

            TempData["success"] = "Catergory Deleted Successfully";

            return RedirectToAction("Index");
        }
    }
}
