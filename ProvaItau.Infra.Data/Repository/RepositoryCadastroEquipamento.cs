using System;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repository.Contracts;

namespace Projeto.Infra.Data.Repository
{
    public class RepositoryCadastroEquipamento : RepositoryBase<CadastroEquipamento>, IRepositoryCadastroEquipamento
    {
        public RepositoryCadastroEquipamento(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
