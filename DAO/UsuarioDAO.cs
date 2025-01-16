using Dapper;
using Microsoft.Data.SqlClient;
using POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
	public class UsuarioDAO
	{

		public Usuario Login(string cpf, string senha, bool LoginInterno)
		{
			SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);
			string sql = "";

			if (LoginInterno)
				sql = @"SELECT u.CodUsuario, p.Cpf, p.Nome, p.Senha, p.Ativo
	                    FROM Usuario u
		                INNER JOIN Pessoa p
	                    ON u.CodUsuario = p.CodPessoa
	                    WHERE p.Cpf = @cpf 
                        AND p.Ativo = 1";

			else
				sql = @"SELECT  
	                    u.CodUsuario,
	                    p.Cpf,
	                    p.Nome,
	                    p.Senha,
	                    p.Ativo
	                    --u.DataHora,
	                    --u.Ramal
	                    FROM Usuario u
	                    INNER JOIN Pessoa p
	                    ON u.CodUsuario = p.CodPessoa
	
	                    WHERE p.Cpf = @cpf 
                        AND p.Senha = @senha
                        AND p.Ativo = 1";

			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@cpf", cpf);
			parameters.Add("@senha", senha);

			try
			{
				var result = conexao.QueryFirstOrDefault<Usuario>(sql, parameters);
				return result;
			}

			catch (Exception ex)
			{
				string e = ex.Message;
				return null;
			}

			finally
			{
				conexao.Close();
			}
		}

		public Usuario Obter(int CodPessoa, string Senha)
		{
			SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

			string sql = $@"SELECT * FROM Usuario u
                            INNER JOIN Pessoa p ON u.CodUsuario = p.CodUsuario
                            WHERE p.CodPessoa = @CodPessoa  and p.Senha = @Senha";

			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@CodPessoa", CodPessoa);
			parameters.Add("@Senha", Senha);

			try
			{
				var result = conexao.QueryFirstOrDefault<Usuario>(sql, parameters);
				return result;
			}
			catch (Exception ex)
			{
				string e = ex.Message;
				return null;
			}
			finally
			{
				conexao.Close();
			}
		}

		public bool AlterarSenha(string Senha, int CodPessoa, int CodUsuario)
		{
			SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

			string sql = @" UPDATE Pessoa SET 
                            Senha = @Senha,
                            CodUsuario_Modificado = @CodUsuario,
                            DataHora_Modificado = GETDATE()
                            WHERE CodPessoa = @CodPessoa";

			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Senha", Senha);
			parameters.Add("@CodPessoa", CodPessoa);
			parameters.Add("@CodUsuario", CodUsuario);

			try
			{
				var result = conexao.Execute(sql, parameters);
				return true;
			}
			catch (Exception ex)
			{
				string e = ex.Message;
				return false;
			}
			finally
			{
				conexao.Close();
			}
		}

		public (int, string)[] GetPermissoes(int CodUsuario)
		{
			SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

			string sql = $@" DECLARE
	                            @CodUsuario int =  {CodUsuario}

                            SELECT 
	                            usu.CodGrupoUsuario, gu.Descricao

                            FROM UsuarioGrupoUsuario usu
	                            INNER JOIN GrupoUsuario gu
	                            ON usu.CodGrupoUsuario = gu.CodGrupoUsuario

                            WHERE 
	                            usu.CodUsuario = @CodUsuario
                                AND (usu.DataFim  IS NULL OR usu.DataFim > GETDATE());";


			try
			{
				var result = conexao.Query<(int, string)>(sql).ToArray();
				return result;
			}
			catch (Exception ex)
			{
				string e = ex.Message;
				return null;
			}
			finally
			{
				conexao.Close();
			}
		}
	}
}
