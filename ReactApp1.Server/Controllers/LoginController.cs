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

		//[HttpPost("login/", Name = "login")]
		//public async Task<IActionResult> Index(LoginViewModel model)
		//{

		//	if (!string.IsNullOrEmpty(model.Cpf) && !string.IsNullOrEmpty(model.Senha))
		//	{
		//		byte CodEmpresa = byte.Parse(Utilitarios.DecriptUrl(model.CodEmpresa));

		//		model.LoginInterno = SelfIPAddress(HttpContext, CodEmpresa);

		//		if (TempData["captcha"].ToString() == model.CodCaptcha)
		//		{
		//			string senha = Utilitarios.GetMD5Hash(model.Senha);
		//			string cpf = Utilitarios.limparCpf_Pis(model.Cpf);

		//			//model.LoginInterno = false;

		//			var user = usBll.Login(cpf, senha, model.LoginInterno);
		//			if (user != null)
		//			{
		//				var prm = usBll.GetPermissoes(user.CodUsuario);

		//				user.Permissao = string.Join(",", prm.Where(x => x.Item1 != 0).Select(x => x.Item2));
		//				user.CodEmpresa = CodEmpresa;

		//				string host = Dns.GetHostName();

		//				bool autentica = await SetDataUser(user);
		//				if (autentica)
		//				{
		//					return RedirectToAction("Index", "EscolherConcurso");
		//				}
		//				else
		//				{
		//					//model.UrlImagemCaptcha = ReturnCaptcha();
		//					ViewBag.Mensagem = "Usuário ou senha inválida";
		//				}
		//			}
		//			else
		//			{
		//				//model.UrlImagemCaptcha = ReturnCaptcha();
		//				ViewBag.Mensagem = "Não foi possível localizar Usuário";
		//			}
		//		}
		//		else if (model.LoginInterno)
		//		{
		//			string senha = Utilitarios.GetMD5Hash(model.Senha);
		//			string cpf = Utilitarios.limparCpf_Pis(model.Cpf);

		//			model.LoginInterno = true;

		//			string host = Dns.GetHostName();

		//			var user = usBll.Login(cpf, senha, model.LoginInterno);
		//			if (user != null)
		//			{
		//				var prm = usBll.GetPermissoes(user.CodUsuario);

		//				user.Permissao = string.Join(",", prm.Where(x => x.Item1 != 0).Select(x => x.Item2));
		//				user.CodEmpresa = CodEmpresa;

		//				bool autentica = await SetDataUser(user);
		//				if (autentica)
		//				{
		//					return RedirectToAction("Index", "EscolherConcurso");
		//				}
		//				else
		//				{
		//					//model.UrlImagemCaptcha = ReturnCaptcha();
		//					ViewBag.Mensagem = "Usuário ou senha inválida";
		//				}
		//			}
		//		}
		//		else
		//		{
		//			ViewBag.mensagem = "O código captcha fornecido está incorreto.";
		//			//model.UrlImagemCaptcha = ReturnCaptcha();
		//			return View(model);
		//		}
		//	}
		//	else
		//	{
		//		ViewBag.Mensagem = "Favor informar o CPF e a senha";
		//	}
		//	//model.UrlImagemCaptcha = ReturnCaptcha();
		//	return View(model);
		//}


		[HttpGet("login/")]
		public IActionResult Login([FromBody] LoginRequest request)
		{
			// Substitua pela lógica de autenticação real
			if (request.Cpf == "123456789" && request.Password == "password123")
			{
				return Ok(new { Message = "Login realizado com sucesso!" });
			}

			return Unauthorized(new { Message = "Credenciais inválidas." });
		}

	}
}
