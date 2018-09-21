using System.Collections.Generic;
using Projeto.Domain.Entities;

namespace Projeto.Service.DTO
{
    public class ChamadoInstalacaoDTO : BaseEntity
    {
        public int Numero { get; set; }

        IEnumerable<AtendimentoChamadoInstalacao> Atendimentos;
    }
}