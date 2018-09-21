using System;
namespace Projeto.Domain.Entities
{
    public class EquipamentoUtilizadoAtendimentoChamadoInstalacao : BaseEntity
    {
        public CadastroEquipamento Equipamento
        {
            get;
            set;
        }

        public AtendimentoChamadoInstalacao Atendimento
        {
            get;
            set;
        }

        public MotivoAvariaEquipamento Motivo
        {
            get;
            set;
        }
    }
}
