using System.ComponentModel.DataAnnotations;

namespace OAuth.Models
{
	public class Role
	{
		[Key]
		public int id { get; set; }
		public string rolename { get; set; }
	}
}
