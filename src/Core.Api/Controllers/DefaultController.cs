using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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