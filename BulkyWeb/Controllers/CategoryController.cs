using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

            /*
             * 
            string pattern = @"\d";

            // Use Regex.IsMatch to check if the string contains a digit
            bool containsNumber = Regex.IsMatch(obj.Name.ToString(), pattern);
            if (containsNumber)
            {
                ModelState.AddModelError("Name", "Name can not contain Number");
            }
            */

            if (ModelState.IsValid)
            {
                _db.Categorys.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
