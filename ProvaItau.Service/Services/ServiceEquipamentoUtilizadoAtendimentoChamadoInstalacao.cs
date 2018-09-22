using System;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Repository.Contracts;
using Projeto.Service.DTO;
using Projeto.Service.Services.Contracts;

namespace Projeto.Service.Services
{
    public class ServiceEquipamentoUtilizadoAtendimentoChamadoInstalacao : ServiceBase<EquipamentoUtilizadoAtendimentoChamadoInstalacao, EquipamentoUtilizadoAtendimentoChamadoInstalacaoDTO>, IServiceEquipamentoUtilizadoAtendimentoChamadoInstalacao
    {
        private readonly IRepositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao _repositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao;
        private readonly IMapper _mapper;

        public ServiceEquipamentoUtilizadoAtendimentoChamadoInstalacao(IMapper mapper, IRepositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao repositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao) : base(mapper, repositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao)
        {
            _mapper = mapper;
            _repositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao = repositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao;
        }

        public void RegistraEquipamentoUtilizado(EquipamentoUtilizadoAtendimentoChamadoInstalacaoDTO equipamento)
        {
            _repositoryEquipamentoUtilizadoAtendimentoChamadoInstalacao.RegistraEquipamentoUtilizado(_mapper.Map<EquipamentoUtilizadoAtendimentoChamadoInstalacao>(equipamento));
        }
    }
}