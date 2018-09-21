using System;
using System.Collections.Generic;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Repository.Contracts;
using Projeto.Service.DTO;
using Projeto.Service.Services.Contracts;

namespace Projeto.Service.Services
{
    public class ServiceMotivoAvariaEquipamento : ServiceBase<MotivoAvariaEquipamento, MotivoAvariaEquipamentoDTO>, IServiceMotivoAvariaEquipamento
    {
        private readonly IRepositoryMotivoAvariaEquipamento _repositoryMotivoAvariaEquipamento;
        private readonly IMapper _mapper;

        public ServiceMotivoAvariaEquipamento(IMapper mapper, IRepositoryMotivoAvariaEquipamento repositoryMotivoAvariaEquipamento) : base(mapper, repositoryMotivoAvariaEquipamento)
        {
            _repositoryMotivoAvariaEquipamento = repositoryMotivoAvariaEquipamento;
            _mapper = mapper;
        }

        public IEnumerable<MotivoAvariaEquipamentoDTO> GetMotivos()
        {
            return _mapper.Map<IEnumerable<MotivoAvariaEquipamentoDTO>>(_repositoryMotivoAvariaEquipamento.GetMotivos());
        }
    }
}
