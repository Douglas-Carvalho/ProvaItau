using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class CadastroEquipamento : BaseEntity
    {
        public string Nome
        {
            get;
            set;
        }

        public float Preco
        {
            get;
            set;
        }
    }
}

