using Microsoft.AspNetCore.Mvc;
using BulkyWeb.Data;
using BulkyWeb.Models;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db; 
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        List<Category> objCategoryList = _db.Categories.ToList();
        return View(objCategoryList);
    }
}