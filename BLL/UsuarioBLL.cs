using DAO;
using POJO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
	public class UsuarioBLL
	{
		private UsuarioDAO dao;
		public UsuarioBLL()
		{
			dao = new UsuarioDAO();
		}

		public Usuario Login(string cpf, string senha, bool LoginInterno)
		{
			return dao.Login(cpf, senha, LoginInterno);
		}

		public Usuario Obter(int CodPessoa, string Senha)
		{
			return dao.Obter(CodPessoa, Senha);
		}

		public bool AlterarSenha(string Senha, int CodPessoa, int CodUsuario)
		{
			return dao.AlterarSenha(Senha, CodPessoa, CodUsuario);
		}

		public (int, string)[] GetPermissoes(int CodUsuario)
		{
			return dao.GetPermissoes(CodUsuario);
		}
	}
}
