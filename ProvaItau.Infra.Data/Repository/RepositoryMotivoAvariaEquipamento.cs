using System;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repository.Contracts;

namespace Projeto.Infra.Data.Repository
{
    public class RepositoryMotivoAvariaEquipamento : RepositoryBase<MotivoAvariaEquipamento>, IRepositoryMotivoAvariaEquipamento
    {
        public RepositoryMotivoAvariaEquipamento(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
