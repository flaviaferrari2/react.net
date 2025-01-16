using POJO;
using System.ComponentModel.DataAnnotations;

namespace SisControl.Web.ViewModels
{
	public class LoginViewModel
	{
		public short CodUsuario { get; set; }
		public string Nome { get; set; }

		[Required(ErrorMessage = "Campo obrigatório")]
		public string Cpf { get; set; }

		[Required(ErrorMessage = "Campo obrigatório")]
		public string Senha { get; set; }

		public string Ramal { get; set; }
		public byte CodFuncaoEmpresa { get; set; }
		public string CodEmpresa { get; set; }
		public short CodConcurso { get; set; }
		public string ConcursoNome { get; set; }
		public bool LoginInterno { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[Display(Name = "Mostre-nos que você não é um robô.")]
		public string CodCaptcha { get; set; }
		public string Permissao { get; set; }
		public string UrlImagemCaptcha { get; set; }
		public string Acesso { get; set; }
		public bool Homologacao { get; set; }

	}
}
