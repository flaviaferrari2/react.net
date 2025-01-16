using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
	public class IPConfigAcessoDAO
	{
		public bool VerificaIP(byte CodEmpresa, string OriginalIP, string RemoteIP, string IP)
		{
			SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

			string where = @"";

			if (CodEmpresa != 0)
			{
				where = @" where CodEmpresa = @CodEmpresa";
			}

			string SQL = $@"select IP from IPConfigAcesso {where}";

			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@CodEmpresa", CodEmpresa);

			try
			{
				var result = conexao.Query<string>(SQL, parameters).ToList();

				if (result.Contains(OriginalIP) || result.Contains(RemoteIP) || result.Contains(IP))
					return true;

				return false;
			}

			catch (Exception ex)
			{
				return false;
			}

			finally
			{
				conexao.Close();
			}
		}
	}
}
