using Microsoft.AspNetCore.Mvc;
using BookAppSolution.DataAccess;
using BookAppSolution.Models;
using BookAppSolution.DataAccess.Repository.IRepository;
using BookAppSoultion.Models;

namespace BookApp.Areas.Admin.Controllers
{

    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = unitOfWork.Product.GetAll();

            return View(objProductList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
           
            if (ModelState.IsValid)
            {
                unitOfWork.Product.Add(obj);
                unitOfWork.Save();

                TempData["success"] = "Cover Type Created Successfully";

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
            var categoryFromDb = unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                unitOfWork.Product.Update(obj);
                unitOfWork.Save();

                TempData["success"] = "Cover Type Edited Successfully";

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
            var coverTypeFromDbFirst = unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

            if (coverTypeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(coverTypeFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            unitOfWork.Product.Remove(obj);
            unitOfWork.Save();

            TempData["success"] = "Cover Type Deleted Successfully";

            return RedirectToAction("Index");
        }
    }
}
