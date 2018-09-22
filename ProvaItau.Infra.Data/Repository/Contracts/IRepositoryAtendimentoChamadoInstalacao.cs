using System;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Repository.Contracts
{
    public interface IRepositoryAtendimentoChamadoInstalacao : IRepositoryBase<AtendimentoChamadoInstalacao>
    {
        int VerificaAtendimentoChamado(int numeroChamado);

        int RegistraAtendimentoChamado(AtendimentoChamadoInstalacao atendimento);
    }
}
