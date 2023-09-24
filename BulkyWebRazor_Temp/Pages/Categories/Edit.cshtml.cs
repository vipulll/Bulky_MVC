using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class EditModel : PageModel
    {

        //private readonly ApplicationDbContext _db;
        //public Category CategoriesList { get; set; }
        //public EditModel(ApplicationDbContext db)
        //{
        //    _db = db;
        //}
        public void OnGet()
        {
        }

        //public IActionResult OnPost()
        //{
        //    //_db.Categories.Update();
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}
