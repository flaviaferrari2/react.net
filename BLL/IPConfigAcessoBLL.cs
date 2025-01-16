using DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
	public class IPConfigAcessoBLL
	{
		private IPConfigAcessoDAO dao;

		public IPConfigAcessoBLL()
		{
			dao = new IPConfigAcessoDAO();
		}

		public bool VerificaIP(byte CodEmpresa, string OriginalIP, string RemoteIP, string IP)
		{
			return dao.VerificaIP(CodEmpresa, OriginalIP, RemoteIP, IP);
		}
	}
}
