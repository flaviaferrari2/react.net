using System;
using System.Collections.Generic;

namespace POJO
{
	public partial class Usuario : Pessoa
	{
		public int CodUsuario { set; get; }
		public string Ramal { set; get; }
		public byte CodFuncaoEmpresa { set; get; }
		public DateTime DataHora { set; get; }
		public int CodUsuario_Modificado { set; get; }
		public string DataHora_Modificado { set; get; }
		//public short CodUsuario { get; set; }
		//public string Nome { get; set; }
		//public string Cpf { get; set; }
		//public string Senha { get; set; }
		//public string Ramal { get; set; }
		//public byte CodFuncaoEmpresa { get; set; }
		//public byte CodSetor { get; set; }
		public byte CodEmpresa { get; set; }
		public short CodConcurso { get; set; }
		public string ConcursoNome { get; set; }

		public string Empresa { get; set; }
		public string Permissao { get; set; }

		//public short CodGrupoUsuario { get; set; }
	}
}