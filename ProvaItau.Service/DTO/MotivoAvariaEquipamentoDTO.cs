using System;
using Projeto.Domain.Entities;

namespace Projeto.Service.DTO
{
    public class MotivoAvariaEquipamentoDTO : BaseEntity
    {
        public ResponsavelOrigemAvariaEquipamentoDTO Responsavel
        {
            get;
            set;
        }

        public string MotivoAvaria
        {
            get;
            set;
        }
    }
}
