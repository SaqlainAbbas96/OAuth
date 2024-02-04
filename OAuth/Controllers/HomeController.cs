using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAuth.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : Controller
	{
		[HttpGet("Hello")]
		public ActionResult<string> Hello()
		{
			return "Hello World from Home Controller";
		}

		[HttpGet("AdminDashboard")]
		[Authorize(Roles = "Admin")]
		public ActionResult<string> AdminDashboard()
		{
			return "Welcome to Admin Dashboard";
		}

		[HttpGet("UserDashboard")]
		[Authorize(Roles = "User")]
		public ActionResult<string> UserDashboard()
		{
			return "Welcome to User Dashboard";
		}
	}
}
