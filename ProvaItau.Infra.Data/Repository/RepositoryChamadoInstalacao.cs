using System;
using System.Data.SqlClient;
using Dapper;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repository.Contracts;

namespace Projeto.Infra.Data.Repository
{
	public class RepositoryChamadoInstalacao : RepositoryBase<ChamadoInstalacao>, IRepositoryChamadoInstalacao
	{
		public RepositoryChamadoInstalacao(ApplicationContext applicationContext) : base(applicationContext)
		{
		}

        public ChamadoInstalacao FindByNumber(int number)
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    return conn.QueryFirstOrDefault<ChamadoInstalacao>(
                           "SELECT Id, NumeroChamado FROM ChamadoInstalacao WHERE NumeroChamado = @NumeroChamado",
                            new { NumeroChamado = number });
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
