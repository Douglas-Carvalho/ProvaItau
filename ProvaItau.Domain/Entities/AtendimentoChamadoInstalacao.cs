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

        public int ChamadoId
        {
            get;
            set;
        }
    }
}
