using System;
using System.Collections.Generic;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Repository.Contracts
{
    public interface IRepositoryMotivoAvariaEquipamento : IRepositoryBase<MotivoAvariaEquipamento>
    {
        IEnumerable<MotivoAvariaEquipamento> GetMotivos();
    }
}
