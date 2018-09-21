using Projeto.Domain.Entities;

namespace Projeto.Service.DTO
{
    public class CadastroEquipamentoDTO : BaseEntity
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
