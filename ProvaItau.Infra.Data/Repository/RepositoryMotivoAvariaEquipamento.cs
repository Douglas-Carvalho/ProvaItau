using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repository.Contracts;

namespace Projeto.Infra.Data.Repository
{
    public class RepositoryMotivoAvariaEquipamento : RepositoryBase<MotivoAvariaEquipamento>, IRepositoryMotivoAvariaEquipamento
    {
        public RepositoryMotivoAvariaEquipamento(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public IEnumerable<MotivoAvariaEquipamento> GetMotivos()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    return conn.Query<MotivoAvariaEquipamento, ResponsavelOrigemAvariaEquipamento, MotivoAvariaEquipamento>(
                        "SELECT M.*, R.* FROM MotivoAvariaEquipamento M INNER JOIN ResponsavelOrigemAvariaEquipamento R ON R.Id = M.Id_ResponsavelOrigemAvariaEquipamento",
                        (motivo, responsavel) => {
                            motivo.Responsavel = responsavel;
                            return motivo;
                    }, CommandType.Text);
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
