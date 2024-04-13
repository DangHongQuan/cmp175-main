using cmp175.Models;
using cpm175.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmp175.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LessonController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public LessonController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/lesson
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Lesson>>> GetLessons()
		{
			return await _context.Lessons.ToListAsync();
		}

		// GET: api/lesson/1/examples
		[HttpGet("{lessonId}/examples")]
		public async Task<ActionResult<IEnumerable<Example>>> GetExamplesByLessonId(int lessonId)
		{
			var examples = await _context.Examples
										.Where(e => e.LessonId == lessonId)
										.ToListAsync();

			return examples;
		}
		// GET: api/example/{exampleId}/examplecontents
		[HttpGet("{exampleId}/examplecontents")]
		public async Task<ActionResult<IEnumerable<ExampleContent>>> GetExampleContentsByExampleId(int exampleId)
		{
			var exampleContents = await _context.ExampleContents
												.Where(ec => ec.ExampleId == exampleId)
												.ToListAsync();

			return exampleContents;
		}

		// GET: api/example/{exampleId}/contentdetails
		[HttpGet("{exampleId}/contentdetails")]
		public async Task<ActionResult<IEnumerable<ContentDetail>>> GetContentDetailsByExampleId(int exampleId)
		{
			var contentDetails = await _context.ContentDetails
												.Where(cd => cd.ExampleId == exampleId)
												.ToListAsync();

			return contentDetails;
		}
	}
}
