using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAuth.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult<string> Hello()
		{
			return "Hello World from Home Controller";
		}
	}
}
