using Microsoft.AspNetCore.Mvc;

namespace cmp175.Controllers
{
	public class FreeLessonController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
