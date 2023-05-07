using Bulky.DataAcess.Data;
using Bulky.DataAcess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepo; 
    public CategoryController(ICategoryRepository db)
    {
        _categoryRepo = db;
    }
    // GET
    public IActionResult Index()
    {
        List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
        return View(objCategoryList);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    // POST
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
        }

        if (ModelState.IsValid)
        {
            _categoryRepo.Add(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index"); // коли людина створила, перенаправляємо її на Index
        }

        return View();
    }

    
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
            return NotFound();

        Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
        
        if (categoryFromDb == null)
            return NotFound();
        
        return View(categoryFromDb);
    }
    // POST
    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _categoryRepo.Update(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category update successfully";
            return RedirectToAction("Index"); // коли людина створила, перенаправляємо її на Index
        }

        return View();
    }
    
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
            return NotFound();

        Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
        
        if (categoryFromDb == null)
            return NotFound();
        
        return View(categoryFromDb);
    }
    // POST
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Category? obj = _categoryRepo.Get(u => u.Id == id);
        if (obj == null)
            return NotFound();
        
        _categoryRepo.Remove(obj);
        _categoryRepo.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}