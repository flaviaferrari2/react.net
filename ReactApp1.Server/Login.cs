using POJO;
using System.ComponentModel.DataAnnotations;

namespace ReactApp1.Server.Model
{
	public class LoginRequest
	{
		public string Cpf { get; set; }
		public string Password { get; set; }
	}
}
