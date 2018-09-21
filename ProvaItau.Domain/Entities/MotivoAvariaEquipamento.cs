using System;
namespace Projeto.Domain.Entities
{
    public class MotivoAvariaEquipamento : BaseEntity
    {

        public ResponsavelOrigemAvariaEquipamento Responsavel
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
