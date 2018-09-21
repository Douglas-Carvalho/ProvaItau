using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dommel;
using Microsoft.Extensions.Configuration;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repository.Contracts;

namespace Projeto.Infra.Data.Repository
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		public string ConnectionString { get; private set; }

		public RepositoryBase(ApplicationContext applicationContext)
		{
			ConnectionString = applicationContext.GetConnectioString();
		}
		
		public void Add(TEntity item)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> FindAll()
		{
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    return conn.GetAll<TEntity>();
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

		public TEntity FindById(int id)
		{
			try
			{
				using (var conn = new SqlConnection(ConnectionString))
				{
					return conn.Get<TEntity>(id);
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

		public void Remove(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(TEntity item)
		{
			throw new NotImplementedException();
		}
	}
}
