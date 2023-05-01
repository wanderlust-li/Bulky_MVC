using BulkyWebRazor_Temp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulkyWebRazor_Temp.Models;

namespace BulkyWebRazor_Temp.Pages.Categories;

public class Index : PageModel
{
    private readonly ApplicationDbContext _db;
    public List<Category> CategoryList { get; set; }
    public Index(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        CategoryList = _db.Categories.ToList();
        
    }
}