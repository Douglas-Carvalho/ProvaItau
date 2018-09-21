using System;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Repository.Contracts;
using Projeto.Service.DTO;
using Projeto.Service.Services.Contracts;

namespace Projeto.Service.Services
{
    public class ServiceCadastroEquipamento : ServiceBase<CadastroEquipamento, CadastroEquipamentoDTO>, IServiceCadastroEquipamento
    {
        public ServiceCadastroEquipamento(IMapper mapper, IRepositoryCadastroEquipamento repositoryCadastroEquipamento) : base(mapper, repositoryCadastroEquipamento)
        {
        }
    }
}
