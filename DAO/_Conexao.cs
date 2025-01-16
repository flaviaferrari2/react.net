using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class _Conexao
	{
		public static string StringDeConexao
		{
			get
			{
				string connectionString;

				#if DEBUG
						connectionString = @"Server=4.228.56.135;Database=concurso-sql01;User ID=U_Sistema;Password=ly-_93v-£2.BbK.7Rp3+Oo9I;Encrypt=True;TrustServerCertificate=true;";
						//connectionString = @"Server=4.228.56.135;Database=concurso-sql01;User ID=U_Desenvolvimento;Password=T66)vvX)~o:N8`?D9£h#k5n5;Encrypt=True;TrustServerCertificate=true;";
				#elif DEVELOPER
	                connectionString = @"Server=4.228.56.135;Database=_HML_concurso-sql01;User ID=U_Desenvolvimento;Password=T66)vvX)~o:N8`?D9£h#k5n5;Encrypt=True;TrustServerCertificate=true;"; 
				#else
                     connectionString = @"Server=4.228.56.135;Database=concurso-sql01;User ID=U_SistemaRestrito;Password=ly-_93v-t22BbK-a7Rp3_Oo9;Encrypt=True;TrustServerCertificate=true;Connect Timeout=120;";

				#endif

				return connectionString;
			}
		}
	}
}
