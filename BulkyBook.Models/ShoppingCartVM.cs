namespace BulkyBook.Models;

public class ShoppingCartVM
{
    public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
    
    public double OrderTotal { get; set; }
}