using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
	[ApiController]
	[Route("/")]

	public class DefaultController : ControllerBase
	{
		[HttpGet]

		public string Index()
		{
			return "Ejecutando ...";
		}
	}
}