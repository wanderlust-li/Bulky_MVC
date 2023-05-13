using System.Diagnostics;
using BulkyBook.DataAcess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.Models;

namespace BulkyBookWeb.Areas.Customer.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includePropetries: "Category");
        return View(productList);
    }
    
    public IActionResult Details(int productID)
    {
        Product product = _unitOfWork.Product.Get(u => u.Id ==productID, includePropetries: "Category");
        return View(product);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}