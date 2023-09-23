using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Category> objCategoryList = _db.Categorys.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // Add anti-forgery token
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","Name can not be same as Display Order");
            }
 
            string pattern = @"\d";
            // Use Regex.IsMatch to check if the string contains a digit
            bool containsNumber = Regex.IsMatch(obj.Name.ToString(), pattern);
            if (containsNumber)
            {
                ModelState.AddModelError("Name", "Name can not contain Number");
            }

            if (ModelState.IsValid)
            {
                _db.Categorys.Add(obj);
                _db.SaveChanges();
                TempData["Sucess"] = "Record Created Sucessfully";
                return RedirectToAction("Index", "Category");
                //return View("Index");
            }
            return View();
        }
        //
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category Cat = _db.Categorys.Find(id);

            Category? Cat1 = _db.Categorys.FirstOrDefault(u => u.Name == "vipull");
            if (Cat == null)
            {
                return NotFound();
            }
            return View(Cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Add anti-forgery token
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Categorys.Update(obj);
                _db.SaveChanges();
                TempData["Sucess"] = "Record Edited Sucessfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Category? Cat1 = _db.Categorys.Find(id);

            return View(Cat1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Add anti-forgery token
        [ActionName("Delete")]
        public IActionResult DeletePOST(Category obj)
        {

            //Category? obj = _db.Categorys.Find(id);
           
                _db.Categorys.Remove(obj);
                _db.SaveChanges();
            TempData["Sucess"] = "Record Delete Sucessfully";
                //return RedirectToAction("Index", "Category");
            
            //return View();
            return RedirectToAction("Index", "Category");
        }

    }
}
