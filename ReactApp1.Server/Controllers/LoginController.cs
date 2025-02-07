using BLL;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SisControl.Web.Controllers;
using SisControl.Web.Models;
using SisControl.Web.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

public class LoginRequest
{
	public string Cpf { get; set; }
	public string Password { get; set; }
}
namespace ReactApp1.Server.Controllers

{
	[ApiController]
	[Route("[controller]")]
	public class LoginController : BaseController
	{
		private readonly UsuarioBLL usBll;

		public LoginController(ILogger<LoginController> logger)
		{
			usBll = new UsuarioBLL();
		}




		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			// Lógica de autenticação de exemplo
			if (request.Cpf == "123456789" && request.Password == "password123")
			{
				return Ok(new { Message = "Login realizado com sucesso!" });
			}

			return Unauthorized(new { Message = "Credenciais inválidas." });
		}
	}

}

