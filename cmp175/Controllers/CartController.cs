using cmp175.Models;
using cpm175.DataAccess;
using Microsoft.AspNetCore.Mvc;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> AddToCart(int sourceId)
    {
        var source = await _context.Sources.FindAsync(sourceId);
        if (source == null)
        {
            return NotFound();
        }

        // Lấy hoặc tạo giỏ hàng từ Session
        var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

        var existingItem = cart.FirstOrDefault(item => item.SourceId == sourceId);

        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cart.Add(new CartItem
            {
                SourceId = source.Id,
                NameSource = source.NameSource,
                Price = source.Price,
                Quantity = 1
            });
        }

        HttpContext.Session.SetObject("Cart", cart);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult ViewCart()
    {
        var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();
        return View(cart);
    }
}