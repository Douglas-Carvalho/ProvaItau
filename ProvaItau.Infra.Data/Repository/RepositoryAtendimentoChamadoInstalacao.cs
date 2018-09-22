using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repository;
using Projeto.Infra.Data.Repository.Contracts;

public class RepositoryAtendimentoChamadoInstalacao : RepositoryBase<AtendimentoChamadoInstalacao>, IRepositoryAtendimentoChamadoInstalacao
{
    public RepositoryAtendimentoChamadoInstalacao(ApplicationContext applicationContext) : base(applicationContext)
    {
    }

    public int RegistraAtendimentoChamado(AtendimentoChamadoInstalacao atendimento)
    {
        try
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.QueryFirstOrDefault<int>(
                    sql: "Stp_RegistraAtendimento",
                    param: new { Data = atendimento.Data, ChamadoId = atendimento.Chamado.Numero }, commandType: CommandType.StoredProcedure);
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

    public int VerificaAtendimentoChamado(int numeroChamado)
    {
        try
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.QueryFirstOrDefault<int>(
                    sql: "StpView_VerificaAtendimentoChamado",
                    param: new { NumeroChamado = numeroChamado }, commandType: CommandType.StoredProcedure) ;
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