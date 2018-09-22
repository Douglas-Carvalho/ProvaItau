using System;
using Projeto.Domain.Entities;

namespace Projeto.Service.DTO
{
    public class EquipamentoUtilizadoAtendimentoChamadoInstalacaoDTO : BaseEntity
    {
        public CadastroEquipamentoDTO Equipamento
        {
            get;
            set;
        }

        public AtendimentoChamadoInstalacaoDTO Atendimento
        {
            get;
            set;
        }

        public MotivoAvariaEquipamentoDTO Motivo
        {
            get;
            set;
        }
    }
}
