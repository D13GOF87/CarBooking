using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Model.DTOs.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public DateTime? FechaNacimiento { get; set; }
		public List<ApplicationUserRole> UserRoles { get; set; }
	}
}
