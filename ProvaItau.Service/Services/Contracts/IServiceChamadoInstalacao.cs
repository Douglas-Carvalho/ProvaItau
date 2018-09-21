using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Entities;
using Projeto.Service.DTO;

namespace Projeto.Service.Services.Contracts
{
	public interface IServiceChamadoInstalacao : IServiceBase<ChamadoInstalacaoDTO>
	{
        ChamadoInstalacaoDTO FindByNumber(int number);
    }
}
