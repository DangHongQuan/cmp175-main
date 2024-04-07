using cmp175.Models;
using Lab3_LTW_TH.Utilitys;
using cpm175.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace cmp175.Controllers
{



    public class SourceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SourceController> _logger;
        private readonly IVideoUrlRepository _videoUrlRepository;
        private readonly ISourceRepository _sourseRepository;




        public SourceController(ApplicationDbContext context, ILogger<SourceController> logger,
            IVideoUrlRepository videoUrlRepository, ISourceRepository sourseRepository)
        {
            _context = context;
            _logger = logger;
            _videoUrlRepository = videoUrlRepository;
            _sourseRepository = sourseRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Mysourse()
        {
            // Lấy thông tin người dùng hiện tại
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (currentUser == null)
            {
                return NotFound();
            }

            // Lấy danh sách các khóa học mà người dùng đã mua
            var sourses = await _context.Sources
                .Where(s => _context.Oders.Any(o => o.UserId == currentUser.Id && o.SourceId == s.Id))
                .ToListAsync();

            return View(sourses);
        }

        public async Task<IActionResult> ViewVideos(int sourseId)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (currentUser == null)
            {
                return NotFound();
            }


            var hasAccess = await _context.Oders.AnyAsync(o => o.UserId == currentUser.Id && o.SourceId == sourseId);

            if (!hasAccess)
            {
                return Forbid();
            }

            var videos = await _context.VideoUrls.Where(v => v.SourceId == sourseId).ToListAsync();
            return View(videos);
        }





        public IActionResult AddSourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSourse(Source sourse, IFormFile imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    sourse.imageUrl = await SaveImage(imageUrl);
                }

                _context.Add(sourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }



        public IActionResult AddVideoUrl()
        {
            var sourseIds = _context.Sources
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = $"NameSourse: {s.NameSource}"
                })
                .ToList();
            ViewBag.SourseIdList = new SelectList(sourseIds, "Value", "Text");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVideoUrl(VideoURL videoUrlddddddddddddd)
        {
            if (ModelState.IsValid)
            {

                _context.Add(videoUrlddddddddddddd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var sourseIds = _context.Sources.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Id.ToString()
            }).ToList();
            ViewBag.SourseIdList = new SelectList(sourseIds, "Id", "NameSourse", videoUrlddddddddddddd.SourceId);

            return View(videoUrlddddddddddddd);
        }


        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return "/images/" + image.FileName;
        }


        public async Task<IActionResult> ShowAllSource()
        {
            var sources = await _context.Sources.ToListAsync();
            return View(sources);
        }


        public async Task<IActionResult> Details(int id)
        {
            var source = await _context.Sources.FirstOrDefaultAsync(s => s.Id == id);
            if (source == null)
            {

                return NotFound();
            }

            return View(source);
        }




    }
}