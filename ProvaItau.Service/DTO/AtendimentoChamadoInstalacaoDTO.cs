using System;
using Projeto.Domain.Entities;

namespace Projeto.Service.DTO
{
    public class AtendimentoChamadoInstalacaoDTO : BaseEntity
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
