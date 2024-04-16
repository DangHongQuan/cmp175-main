using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using cmp175.Models;
using cpm175.DataAccess;

namespace cmp175.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Oder oder)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

                if (currentUser == null)
                {
                    return RedirectToPage("/Login");
                }

                if (string.IsNullOrEmpty(currentUser.Id))
                {
                    ModelState.AddModelError("", "Không thể lấy UserId của người dùng.");
                    return View(oder);
                }

                var order = new Oder()
                {
                    UserId = currentUser.Id,
                    SourceId = oder.SourceId,
                    Name = oder.Name,
                    Address = oder.Address,
                    Phone = oder.Phone,
                    ToltalPrice = oder.ToltalPrice
                };

                _context.Oders.Add(order);
                await _context.SaveChangesAsync();
              
                return RedirectToAction("Index", "Home"); 
            }
            else
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
                    }
                }
        
                return View(oder);
            }
        }
    }
}
