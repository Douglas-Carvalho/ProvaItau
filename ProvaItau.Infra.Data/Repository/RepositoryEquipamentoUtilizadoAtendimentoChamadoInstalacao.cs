using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repository;
using Projeto.Infra.Data.Repository.Contracts;

public class RepositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao : RepositoryBase<EquipamentoUtilizadoAtendimentoChamadoInstalacao>, IRepositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao
{
    public RepositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao(ApplicationContext applicationContext) : base(applicationContext)
    {
    }

    public void RegistraEquipamentoUtilizado(EquipamentoUtilizadoAtendimentoChamadoInstalacao equipamento)
    {
        try
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.QueryFirstOrDefault<int>(
                    sql: "Stp_RegistraEquipamentoUtilizado",
                    param: new { EquipamentoId = equipamento.Equipamento.Id, AtendimentoId = equipamento.Atendimento.Id, MotivoId = equipamento.Motivo.Id }, commandType: CommandType.StoredProcedure);
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