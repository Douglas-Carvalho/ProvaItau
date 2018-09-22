using System;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Repository.Contracts
{
    public interface IRepositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao : IRepositoryBase<EquipamentoUtilizadoAtendimentoChamadoInstalacao>
    {
        void RegistraEquipamentoUtilizado(EquipamentoUtilizadoAtendimentoChamadoInstalacao equipamento);
    }
}
