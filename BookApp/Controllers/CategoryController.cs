using Microsoft.AspNetCore.Mvc;
using BookAppSolution.DataAccess;
using BookAppSolution.Models;

namespace BookApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = db.Categories;

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
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customer Error", "The Display Order cannot exactly make the Name");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(obj);
                db.SaveChanges();

                TempData["success"] = "Catergory Created Successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
            
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = db.Categories.Find(id);

            if(categoryFromDb == null)
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
                db.Categories.Update(obj);
                db.SaveChanges();

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
            var categoryFromDb = db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            db.Categories.Remove(obj);
            db.SaveChanges();

            TempData["success"] = "Catergory Deleted Successfully";

            return RedirectToAction("Index");
        }
    }
}
