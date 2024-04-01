using cmp175.Models;
using cpm175.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LTW_Projeck_CPM174.Controllers
{

    public class OrderController : Controller
    {

        private readonly ApplicationDbContext _context;


        public OrderController(ApplicationDbContext context)
            {
                _context = context;
            }
            [HttpPost]
            public async Task<IActionResult> Create(int sourceId)
            {
            // Lấy thông tin về người dùng đăng nhập
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            // Kiểm tra xem người dùng có đăng nhập không
            if (currentUser == null)
                {
                return RedirectToPage("/Login");
                }

                // Tạo một Order mới
                var order = new Oder
                {
                    OderDateTime = DateTime.Now,
                    SourseId = sourceId,
                    UserId = currentUser.Id
                };

                _context.Oders.Add(order);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home"); // Hoặc chuyển hướng đến trang cảm ơn hoặc bất kỳ trang nào khác bạn muốn
            }
        }

}
