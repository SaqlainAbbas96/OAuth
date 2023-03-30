using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAuth.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : Controller
	{
		[HttpGet, Authorize]
		public ActionResult<string> Hello()
		{
			return "Hello World from Home Controller";
		}
	}
}
