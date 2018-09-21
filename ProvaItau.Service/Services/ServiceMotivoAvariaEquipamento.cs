using System;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Repository.Contracts;
using Projeto.Service.DTO;
using Projeto.Service.Services.Contracts;

namespace Projeto.Service.Services
{
    public class ServiceMotivoAvariaEquipamento : ServiceBase<MotivoAvariaEquipamento, MotivoAvariaEquipamentoDTO>, IServiceMotivoAvariaEquipamento
    {
        public ServiceMotivoAvariaEquipamento(IMapper mapper, IRepositoryMotivoAvariaEquipamento repositoryMotivoAvariaEquipamento) : base(mapper, repositoryMotivoAvariaEquipamento)
        {
        }
    }
}
