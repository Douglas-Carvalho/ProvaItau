using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class ChamadoInstalacao : BaseEntity
    {
        public int Numero { get; set; }

        IEnumerable<AtendimentoChamadoInstalacao> Atendimentos;
    }
}

