using System;
using Projeto.Service.DTO;

namespace Projeto.Service.Services.Contracts
{
    public interface IServiceEquipamentoUtilizadoAtendimentoChamadoInstalacao : IServiceBase<EquipamentoUtilizadoAtendimentoChamadoInstalacaoDTO>
    {
        void RegistraEquipamentoUtilizado(EquipamentoUtilizadoAtendimentoChamadoInstalacaoDTO equipamento);
    }
}


