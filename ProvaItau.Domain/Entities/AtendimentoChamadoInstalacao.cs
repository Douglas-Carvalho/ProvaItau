using System;
namespace Projeto.Domain.Entities
{
    public class AtendimentoChamadoInstalacao : BaseEntity
    {
        public DateTime Data
        {
            get;
            set;
        }

        public ChamadoInstalacao Chamado
        {
            get;
            set;
        }
    }
}
