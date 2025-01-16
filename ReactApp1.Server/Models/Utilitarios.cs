using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;

namespace SisControl.Web.Models
{
	public class Utilitarios
	{
		#region Criptografia de URL

		public static string CriptUrl(string valor)
		{
			try
			{
				string chave = "#Cho053D4t@R0r!s#";

				TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
				des.IV = new byte[8];
				PasswordDeriveBytes pdb = new PasswordDeriveBytes(chave, new byte[-1 + 1]);
				des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
				System.IO.MemoryStream ms = new System.IO.MemoryStream((valor.Length * 2) - 1);
				CryptoStream encStream = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
				byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(valor);
				encStream.Write(plainBytes, 0, plainBytes.Length);
				encStream.FlushFinalBlock();
				byte[] encryptedBytes = new byte[Convert.ToInt32(ms.Length - 1) + 1];
				ms.Position = 0;
				ms.Read(encryptedBytes, 0, Convert.ToInt32(ms.Length));
				encStream.Close();
				string c = null;
				c = Convert.ToBase64String(encryptedBytes).Replace("+", "SimboloMaIs").Replace("/", "barr");
				return c;
			}
			catch
			{
				return "";
			}
		}
		public static string DecriptUrl(string Valor)
		{
			try
			{
				string Chave = "#Cho053D4t@R0r!s#";

				Valor = Valor.Replace("SimboloMaIs", "+").Replace("barr", "/");
				TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
				des.IV = new byte[8];
				PasswordDeriveBytes pdb = new PasswordDeriveBytes(Chave, new byte[-1 + 1]);
				des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
				byte[] encryptedBytes = Convert.FromBase64String(Valor);
				System.IO.MemoryStream MS = new System.IO.MemoryStream(Valor.Length);
				CryptoStream decStreAM = new CryptoStream(MS, des.CreateDecryptor(), CryptoStreamMode.Write);
				decStreAM.Write(encryptedBytes, 0, encryptedBytes.Length);
				decStreAM.FlushFinalBlock();
				byte[] plainBytes = new byte[Convert.ToInt32(MS.Length - 1) + 1];
				MS.Position = 0;
				MS.Read(plainBytes, 0, Convert.ToInt32(MS.Length));
				decStreAM.Close();
				return System.Text.Encoding.UTF8.GetString(plainBytes);
			}
			catch
			{
				return "";
			}
		}

		#endregion

		public static string gerarNumeroRandomico()
		{
			Random oRandom = new Random();
			return oRandom.Next(1111, 9999).ToString();
		}
		public static string GetMD5Hash(string input)
		{
			MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
			byte[] bs = Encoding.UTF8.GetBytes(input);
			bs = x.ComputeHash(bs);
			StringBuilder s = new System.Text.StringBuilder();
			foreach (byte b in bs)
			{
				s.Append(b.ToString("x2").ToLower());
			}
			string password = s.ToString();
			return password;
		}
		public static string limparCpf_Pis(string valor)
		{
			return clearExcessSpace(valor.Replace(".", string.Empty).Replace(",", string.Empty).Replace("-", string.Empty).Replace("_", string.Empty).Trim());
		}
		public static string clearExcessSpace(string frase)
		{
			Regex regex = new Regex(@"\s * | * \s",
			  RegexOptions.IgnoreCase | RegexOptions.Compiled);
			return (regex.Replace(frase, " ")).Trim();
		}
		public static string Inverte(string input)
		{
			char[] array = input.ToCharArray();
			Array.Reverse(array);
			string invertida = new String(array);

			return invertida;
		}
		protected static string GetQuery(string value, string key)
		{
			string stringRegex = "(\\?|\\&){key}=\\d{1,}".Replace("{key}", key);

			RegexOptions options = RegexOptions.None;
			Regex rg = new Regex(stringRegex, options);

			try
			{
				string r = rg.Match(value).Value;
				rg = new Regex(@"\d{1,}", options);


				return rg.Match(r).Value;
			}
			catch
			{
				return "";
			}
		}
		public static string GetFileName(string palavra)
		{
			RegexOptions options = RegexOptions.None;
			Regex rg = new Regex(@"([A-z]|[0-9]){1,}$", options);

			try
			{
				return rg.Match(palavra).Value;
			}
			catch
			{
				return "";
			}
		}
		public static bool ValidaData(string Data)
		{
			Data = Data.ToString().Substring(0, 10);

			string[] partes = Data.Split('/');
			int dia, mes, ano;

			if (int.TryParse(partes[0], out dia) && int.TryParse(partes[1], out mes) && int.TryParse(partes[2], out ano))
			{
				if (ano > 1900)
				{
					if (mes >= 1 && mes <= 12)
					{
						int maxDia = (mes == 2 ? (ano % 4 == 0 ? 29 : 28) : mes <= 7 ? (mes % 2 == 0 ? 30 : 31) : (mes % 2 == 0 ? 31 : 30));

						if (dia < 1 || dia > maxDia)
						{
							return false;
						}

						else
						{
							return true;
						}
					}

					else
					{
						return false;
					}
				}

				else
				{
					return false;
				}
			}

			else
			{
				return false;
			}
		}
		public static bool ValidaHora(string Hora)
		{
			var regexHora = Regex.Match(Hora.ToString(), @"(\d+)\/(\d+)\/(\d+) (\d+):(\d+):(\d+)");

			if (regexHora.Length == 0)
				return false;
			else
				Hora = $"{regexHora.Groups[4].Value}:{regexHora.Groups[5].Value}:{regexHora.Groups[6].Value}";

			string[] partes = Hora.Split(':');
			int hora, minutos, segundos;

			if (int.TryParse(partes[0], out hora) && int.TryParse(partes[1], out minutos) && int.TryParse(partes[2], out segundos))
			{
				if (hora >= 0 && minutos >= 0 && segundos >= 0)
				{
					if (hora < 24 && minutos < 60 && segundos < 60)
					{
						return true;
					}

					else
					{
						return false;
					}
				}

				else
				{
					return true;
				}
			}

			else
			{
				return false;
			}
		}
		public static string GetDate(string Data)
		{
			var day = "";
			var month = "";
			var year = "";

			var hora = "";
			var minuto = "";
			var segundo = "";

			try
			{
				if (Data == null)
				{
					return "NULL";
				}

				else if (!Regex.IsMatch(Data.ToString(), @"(\d+)\/(\d+)\/(\d+) (\d+):(\d+):(\d+)"))
				{
					day = Regex.Match(Data.ToString(), @"(\d+)\/(\d+)\/(\d+)").Groups[1].Value;
					month = Regex.Match(Data.ToString(), @"(\d+)\/(\d+)\/(\d+)").Groups[2].Value;
					year = Regex.Match(Data.ToString(), @"(\d+)\/(\d+)\/(\d+)").Groups[3].Value;

					return Data = $"'{year}{month}{day} 00:00:00'";
				}

				else
				{
					day = Regex.Match(Data.ToString(), @"(\d+)\/(\d+)\/(\d+)").Groups[1].Value;
					month = Regex.Match(Data.ToString(), @"(\d+)\/(\d+)\/(\d+)").Groups[2].Value;
					year = Regex.Match(Data.ToString(), @"(\d+)\/(\d+)\/(\d+)").Groups[3].Value;

					hora = Regex.Match(Data.ToString(), @"(\d+):(\d+):(\d+)").Groups[1].Value;
					minuto = Regex.Match(Data.ToString(), @"(\d+):(\d+):(\d+)").Groups[2].Value;
					segundo = Regex.Match(Data.ToString(), @"(\d+):(\d+):(\d+)").Groups[3].Value;

					return $"'{year}{month}{day} {hora}:{minuto}:{segundo}'";
				}
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public static string GeraToken(string cpf)
		{
			string minuto = DateTime.Now.Hour.ToString("00");
			var CPF = limparCpf_Pis(cpf);

			var invertida = Inverte(CPF);

			var toke = invertida + minuto;

			return GetMD5Hash(toke);
		}
		public static string QueryString(string value, string key)
		{
			if (!string.IsNullOrEmpty(value))
				return GetQuery(value, key);

			return "";
		}
		public static bool validarCpf(string cpf)
		{
			if (cpf == "")
				return false;

			if (cpf.Length != 11)
				return false;

			// Caso coloque todos os numeros iguais
			switch (cpf)
			{
				case "11111111111":
					return false;
				case "00000000000":
					return false;
				case "2222222222":
					return false;
				case "33333333333":
					return false;
				case "44444444444":
					return false;
				case "55555555555":
					return false;
				case "66666666666":
					return false;
				case "77777777777":
					return false;
				case "88888888888":
					return false;
				case "99999999999":
					return false;
			}

			int multiplicador1 = 10;
			int multiplicador2 = 11;

			string tempCpf;
			string digito;
			int soma;
			int resto;

			cpf = limparCpf_Pis(cpf);
			if (cpf.Length != 11)
				return false;

			tempCpf = cpf.Substring(0, 9);
			soma = 0;
			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * (multiplicador1 - i);

			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;

			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * (multiplicador2 - i);

			resto = soma % 11;

			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito = digito + resto.ToString();

			return cpf.EndsWith(digito);

		}
		public static bool isInteger(string p)
		{
			try
			{
				if (string.IsNullOrEmpty(p))
					return false;

				int numero;
				return int.TryParse(p, out numero);
			}
			catch
			{
				return false;
			}
		}
		public static bool isShort(string p)
		{
			try
			{
				if (string.IsNullOrEmpty(p))
					return false;

				short numero;
				return short.TryParse(p, out numero);
			}
			catch
			{
				return false;
			}
		}
		public static bool isByte(string p)
		{
			try
			{
				if (string.IsNullOrEmpty(p))
					return false;

				byte numero;
				return byte.TryParse(p, out numero);
			}
			catch
			{
				return false;
			}
		}
		public static bool ValidaNascimento(string Nascimento)
		{
			string[] partes = Nascimento.Split('/');
			int dia, mes, ano;

			if (int.TryParse(partes[0], out dia) && int.TryParse(partes[1], out mes) && int.TryParse(partes[2], out ano))
			{
				if (ano <= DateTime.Now.Year && ano > 1900)
				{
					if (mes >= 1 && mes <= 12)
					{
						int maxDia = (mes == 2 ? (ano % 4 == 0 ? 29 : 28) : mes <= 7 ? (mes % 2 == 0 ? 30 : 31) : (mes % 2 == 0 ? 31 : 30));

						if (dia < 1 || dia > maxDia)
						{
							return false;
						}

						else
						{
							return true;
						}
					}

					else
					{
						return false;
					}
				}

				else
				{
					return false;
				}
			}

			else
			{
				return false;
			}
		}
		public static string FormataHora(string Data)
		{
			if (!Regex.IsMatch(Data.ToString(), @"(\d+)\/(\d+)\/(\d+) (\d+):(\d+):(\d+)"))
				return Data = $"{Data} 00:00:00";
			else
				return Data;
		}
		public static bool somenteNumeros(string palavra)
		{
			RegexOptions options = RegexOptions.None;
			Regex rg = new Regex(@"^[0-9]+$", options);

			if (rg.IsMatch(palavra))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool somenteLetras(string palavra)
		{
			RegexOptions options = RegexOptions.None;
			Regex rg = new Regex(@"^[a-z\u00C0-\u00ff A-Z \s]+$", options);

			if (rg.IsMatch(palavra))
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		//public static async Task<byte[]> RemoveBackground(byte[] imageBytes)
		//{

		//	if (HasTransparentBackground(imageBytes))
		//	{
		//		return imageBytes;
		//	}
		//	else
		//	{
		//		var src = Cv2.ImDecode(imageBytes, ImreadModes.Color);

		//		// Convert the image to grayscale
		//		var gray = new Mat();
		//		Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

		//		// Threshold the image to create a mask with the black areas
		//		var mask = new Mat();
		//		Cv2.Threshold(gray, mask, 240, 255, ThresholdTypes.BinaryInv);

		//		// Convert the original image to RGBA
		//		var rgba = new Mat();
		//		Cv2.CvtColor(src, rgba, ColorConversionCodes.BGR2BGRA);

		//		// Set the alpha channel to the mask
		//		var channels = Cv2.Split(rgba);
		//		channels[3] = mask;
		//		Cv2.Merge(channels, rgba);

		//		var dst = new Mat<Vec4b>();
		//		rgba.ConvertTo(dst, MatType.CV_8UC4);

		//		return dst.ToBytes(".png");
		//	}


		//	//var image = Cv2.ImDecode(imageBytes, ImreadModes.Color);
		//	//var gray = new Mat();
		//	//Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

		//	//var threshold = new Mat();
		//	//Cv2.Threshold(gray, threshold, 240, 255, ThresholdTypes.BinaryInv);

		//	//Cv2.FindContours(threshold, out Point[][] contours, out HierarchyIndex[] hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
		//	//var maskExpr = Mat.Zeros(image.Size(), MatType.CV_8UC1);
		//	//var mask = maskExpr.ToMat(); 
		//	//Cv2.DrawContours(mask, contours, -1, Scalar.White, -1);

		//	//var result = new Mat();
		//	//image.CopyTo(result, mask);
		//	//return result.ToBytes(".png");
		//}

		//public static bool HasTransparentBackground(byte[] imageBytes)
		//{
		//	var src = Cv2.ImDecode(imageBytes, ImreadModes.Color);

		//	if (src.Channels() != 4)
		//		return false;

		//	var alphaChannel = new Mat();
		//	Cv2.ExtractChannel(src, alphaChannel, 3);
		//	var nonZeroCount = Cv2.CountNonZero(alphaChannel);

		//	return nonZeroCount > 0;
		//}


	}
}
