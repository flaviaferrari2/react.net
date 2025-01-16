using BLL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POJO;
using SisControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.SignalR;
using POJO;

namespace SisControl.Web.Controllers
{
	//[UserFilter]
	public class BaseController : Controller
	{
		//private readonly _LogGeralBLL _logGeral;
		//private readonly _LogErrosBLL _logErros;
		private readonly IPConfigAcessoBLL bll;
		private readonly string _webhookBitrix;


		public BaseController()
		{
			bll = new IPConfigAcessoBLL();
			//_logGeral = new _LogGeralBLL();
			//_logErros = new _LogErrosBLL();
			_webhookBitrix = "https://consulplanconsultoria.bitrix24.com.br/rest/117/m6gqz0iuxku9112v";
		}

		#region Captcha

		[HttpGet]
		//public JsonResult GetCaptcha()
		//{
		//	try
		//	{
		//		return Json(ReturnCaptcha());
		//	}
		//	catch
		//	{
		//		return Json("");
		//	}
		//}

		//protected string ReturnCaptcha()
		//{
		//	try
		//	{
		//		string base64 = "";
		//		var hash = Utilitarios.gerarNumeroRandomico();
		//		TempData["captcha"] = hash;

		//		if (!string.IsNullOrEmpty(hash))
		//		{
		//			int iHeight = 100;
		//			int iWidth = 200;
		//			Random oRandom = new Random();

		//			int[] aBackgroundNoiseColor = new int[] { 150, 150, 150 };
		//			int[] aTextColor = new int[] { 0, 0, 0 };
		//			int[] aFontEmSizes = new int[] { 22, 24, 26, 28, 30 };

		//			string[] aFontNames = new string[] { "Comic Sans MS", "Arial", "Times New Roman", "Georgia", "Verdana", "Geneva" };

		//			FontStyle[] aFontStyles = new FontStyle[] { FontStyle.Bold, FontStyle.Italic, FontStyle.Regular, FontStyle.Strikeout, FontStyle.Underline };
		//			HatchStyle[] aHatchStyles = new HatchStyle[]
		//			{
		//				HatchStyle.BackwardDiagonal, HatchStyle.Cross,                 HatchStyle.DashedDownwardDiagonal,
		//				HatchStyle.DashedHorizontal, HatchStyle.DashedUpwardDiagonal,  HatchStyle.DashedVertical,
		//				HatchStyle.DiagonalBrick,    HatchStyle.DiagonalCross,         HatchStyle.Divot,
		//				HatchStyle.DottedDiamond,    HatchStyle.DottedGrid,            HatchStyle.ForwardDiagonal,
		//				HatchStyle.Horizontal,       HatchStyle.HorizontalBrick,       HatchStyle.LargeCheckerBoard,
		//				HatchStyle.LargeConfetti,    HatchStyle.LargeGrid,             HatchStyle.LightDownwardDiagonal,
		//				HatchStyle.LightHorizontal,  HatchStyle.LightUpwardDiagonal,   HatchStyle.LightVertical,
		//				HatchStyle.Max,              HatchStyle.Min,                   HatchStyle.NarrowHorizontal,
		//				HatchStyle.NarrowVertical,   HatchStyle.OutlinedDiamond,       HatchStyle.Plaid,
		//				HatchStyle.Shingle,          HatchStyle.SmallCheckerBoard,     HatchStyle.SmallConfetti,
		//				HatchStyle.SmallGrid,        HatchStyle.SolidDiamond,          HatchStyle.Sphere,
		//				HatchStyle.Trellis,          HatchStyle.Vertical,              HatchStyle.Wave,
		//				HatchStyle.Weave,            HatchStyle.WideDownwardDiagonal,  HatchStyle.WideUpwardDiagonal,
		//				HatchStyle.ZigZag
		//			};

		//			string sCaptchaText = hash;

		//			Bitmap oOutputBitmap = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
		//			Graphics oGraphics = Graphics.FromImage(oOutputBitmap);
		//			oGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;

		//			RectangleF oRectangleF = new RectangleF(0, 0, iWidth, iHeight);
		//			Brush oBrush = default(Brush);

		//			oBrush = new HatchBrush(aHatchStyles[oRandom.Next(aHatchStyles.Length - 1)],
		//									Color.FromArgb((oRandom.Next(100, 255)),
		//									(oRandom.Next(100, 255)),
		//									(oRandom.Next(100, 255))),
		//									Color.White);

		//			oGraphics.FillRectangle(oBrush, oRectangleF);

		//			Matrix oMatrix = new Matrix();
		//			int i = 0;
		//			for (i = 0; i <= sCaptchaText.Length - 1; i++)
		//			{
		//				oMatrix.Reset();
		//				int iChars = sCaptchaText.Length;
		//				int x = iWidth / (iChars + 1) * i;
		//				int y = iHeight / 2;

		//				//Rotate text Random
		//				oMatrix.RotateAt(oRandom.Next(-40, 40), new PointF(x, y));
		//				oGraphics.Transform = oMatrix;

		//				//Draw the letters with Random Font Type, Size and Color
		//				oGraphics.DrawString
		//				(
		//					//Text
		//					sCaptchaText.Substring(i, 1),
		//					//Random Font Name and Style
		//					new Font(aFontNames[oRandom.Next(aFontNames.Length - 1)],
		//					   aFontEmSizes[oRandom.Next(aFontEmSizes.Length - 1)],
		//					   aFontStyles[oRandom.Next(aFontStyles.Length - 1)]),
		//					//Random Color (Darker colors RGB 0 to 100)
		//					new SolidBrush(Color.FromArgb(oRandom.Next(0, 100),
		//					   oRandom.Next(0, 100), oRandom.Next(0, 100))),
		//					x,
		//					oRandom.Next(10, 40)
		//				);
		//				oGraphics.ResetTransform();
		//			}

		//			MemoryStream oMemoryStream = new MemoryStream();
		//			oOutputBitmap.Save(oMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
		//			byte[] oBytes = oMemoryStream.GetBuffer();

		//			oOutputBitmap.Dispose();
		//			oMemoryStream.Close();

		//			base64 = string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(oBytes));
		//		}

		//		return base64;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw;
		//	}
		//}

		#endregion


		#region Verificação IP

		public bool SelfIPAddress(HttpContext httpRequest, byte CodEmpresa)
		{
			string OriginalIP = httpRequest.Request.HttpContext.Connection.LocalIpAddress.ToString();
			string RemoteIP = httpRequest.Request.HttpContext.Connection.RemoteIpAddress.ToString();

			string ip = GetIP();

			return bll.VerificaIP(CodEmpresa, OriginalIP ?? "", RemoteIP ?? "", ip ?? "");
		}


		public string GetIP()
		{
			string ip = HttpContext.Request.Headers["CF-Connecting-IP"];
			ip ??= HttpContext.Connection.RemoteIpAddress.ToString();

			return ip;
		}

		#endregion


		#region Set Usuario

		public async Task<bool> SetDataUser(Usuario usuario)
		{
			try
			{
				var userClaims = new List<Claim>()
				{
					new Claim("_us", JsonConvert.SerializeObject(usuario)),
				};

				var minhaIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
				var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });
				var authProperties = new AuthenticationProperties
				{
					//AllowRefresh = <bool>,
					// Refreshing the authentication session should be allowed.

					ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
					// The time at which the authentication ticket expires. A 
					// value set here overrides the ExpireTimeSpan option of 
					// CookieAuthenticationOptions set with AddCookie.

					IsPersistent = false,
					// Whether the authentication session is persisted across 
					// multiple requests. When used with cookies, controls
					// whether the cookie's lifetime is absolute (matching the
					// lifetime of the authentication ticket) or session-based.

					//IssuedUtc = <DateTimeOffset>,
					// The time at which the authentication ticket was issued.

					//RedirectUri = "/Base/Logout"
					// The full path or absolute URI to be used as an http 
					// redirect response value.
				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperties);
				return true;
			}
			catch
			{
				return false;
			}
		}

		#endregion


		#region Retorna Usuario

		public Usuario GetUser()
		{
			try
			{
				var dataArrayCookies = HttpContext.User.Identities.FirstOrDefault().Claims;
				if (dataArrayCookies.Count() > 0 && dataArrayCookies.FirstOrDefault(x => x.Type == "_us").Value != null)
				{
					var usuario = JsonConvert.DeserializeObject<Usuario>(dataArrayCookies.FirstOrDefault(x => x.Type == "_us").Value);
					ViewBag.Nome = usuario.Nome;
					ViewBag.Permissao = usuario.Permissao;					

					return usuario;
				}
				else
					return null;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		#endregion



		#region LogOut
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Login");
		}

		#endregion


		#region Bitrix24

		public async Task<dynamic> CreateTaskBitrix(string titulo, string descricao, int codUsuario)
		{
			var responsavelId = 117;
			var observadores = new int[] { 14, 16, 18, 72, 149, 191, 335, 189, 367 };
			var participantes = new int[] { 6, 363, 1, 289 };
			var criadorId = GetBitrixIdByCodUsuario(codUsuario);
			var deadline = DateTime.Now.AddHours(6).ToString("yyyy-MM-ddTHH:mm:ss");

			var taskData = new
			{
				fields = new
				{
					TITLE = titulo,
					DESCRIPTION = descricao,
					RESPONSIBLE_ID = responsavelId,
					ACCOMPLICES = participantes,
					AUDITORS = observadores,
					CREATED_BY = criadorId,
					DEADLINE = deadline
				}
			};

			var result = await SendRequestAsync("tasks.task.add", taskData, HttpMethod.Post);
			var resultObject = JsonConvert.DeserializeObject<dynamic>(result);
			var taskId = resultObject.result.task.id.ToString();

			SendMessageBitrixBot(taskId);

			//         foreach (var observador in observadores)
			//{
			//	await SendNotificationBitrix(titulo, observador);
			//}

			return Json(new { taskId, deadline, criadorId });
		}

		private int GetBitrixIdByCodUsuario(int codUsuario)
		{
			return codUsuario switch
			{
				59 => 14,
				127 => 16,
				54 => 18,
				144 => 72,
				383 => 149,
				226 => 191,
				190 => 335,
				273 => 189,
				139 => 117,
				168 => 367,
				522057 => 289,
				_ => 117
			};
		}


		public async Task<dynamic> SendNotificationBitrix(string message, int userId)
		{
			var notificationData = new
			{
				USER_ID = userId,
				MESSAGE = message
			};

			var result = await SendRequestAsync("im.notify.json", notificationData, HttpMethod.Get);
			return JsonConvert.DeserializeObject<dynamic>(result);
		}

		private async Task SendMessageBitrixBot(string message)
		{
			var feriasIgor = new List<int> { 117, 363, 6, 289 };

			foreach (var dialogId in feriasIgor)
			{
				string taskUrl = $"https://consulplanconsultoria.bitrix24.com.br/company/personal/user/{dialogId}/tasks/task/view/{message}/";
				string text = $"SisControl4 - Uma tarefa foi aberta: {taskUrl}";

				var chatData = new
				{
					CLIENT_ID = "1zko2szb4z62fesp26smh2ipzggj5r4z",
					BOT_ID = 377,
					DIALOG_ID = dialogId,
					MESSAGE = text
				};

				using (var httpClient = new HttpClient())
				{
					string url = $"https://consulplanconsultoria.bitrix24.com.br/rest/117/wqv7402ohqr87ju7/imbot.message.add.json";

					var properties = from p in chatData.GetType().GetProperties()
									 where p.GetValue(chatData, null) != null
									 select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(chatData, null).ToString());

					var queryString = string.Join("&", properties.ToArray());
					url += "?" + queryString;


					var request = new HttpRequestMessage(HttpMethod.Get, url);

					var response = await httpClient.SendAsync(request);

				}
			}
		}

		public async Task<dynamic> SendMessageBitrix(string message)
		{
			var messageData = new
			{
				DIALOG_ID = 117,
				MESSAGE = message
			};

			var result = await SendRequestAsync("im.message.add.json", messageData, HttpMethod.Get);
			return Json(result);
		}

		private async Task<string> SendRequestAsync(string endpoint, object data, HttpMethod method)
		{
			using (var httpClient = new HttpClient())
			{
				string url = $"{_webhookBitrix}/{endpoint}";
				if (method == HttpMethod.Get && data != null)
				{
					var properties = from p in data.GetType().GetProperties()
									 where p.GetValue(data, null) != null
									 select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(data, null).ToString());

					var queryString = String.Join("&", properties.ToArray());
					url += "?" + queryString;
				}

				var request = new HttpRequestMessage(method, url);
				if (method == HttpMethod.Post)
				{
					request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
				}

				var response = await httpClient.SendAsync(request);

				if (response.IsSuccessStatusCode)
				{
					return await response.Content.ReadAsStringAsync();
				}
				else
				{
					return JsonConvert.SerializeObject(new { error = response.ReasonPhrase });
				}
			}
		}


		#endregion

	}
}
