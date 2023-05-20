using System.Security.Claims;
using BulkyBook.DataAcess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Customer.Controllers;
[Area("Customer")]
[Authorize]
public class CartController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public ShoppingCartVM ShoppingCartVM { get; set; }

    public CartController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    // GET
    public IActionResult Index()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

        ShoppingCartVM = new()
        {
            ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
                includePropetries: "Product")
        };

        foreach (var cart in ShoppingCartVM.ShoppingCartList)
        {
            cart.Price = GetPriceBasedOnQuntity(cart);
            ShoppingCartVM.OrderTotal += (cart.Price * cart.Count);
        }
        
        return View(ShoppingCartVM);
    }

    private double GetPriceBasedOnQuntity(ShoppingCart shoppingCart)
    {
        if (shoppingCart.Count <= 50)
            return shoppingCart.Product.Price;
        else
        {
            if (shoppingCart.Count <= 1000)
            {
                return shoppingCart.Product.Price50;
            }
            else
            {
                return shoppingCart.Product.Price100;
            }
        }
    }
}