using System;
using System.Collections.Generic;
using Projeto.Service.DTO;

namespace Projeto.Service.Services.Contracts
{
    public interface IServiceMotivoAvariaEquipamento : IServiceBase<MotivoAvariaEquipamentoDTO>
    {
        IEnumerable<MotivoAvariaEquipamentoDTO> GetMotivos();
    }
}
