using System;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Repository.Contracts;
using Projeto.Service.DTO;
using Projeto.Service.Services.Contracts;

namespace Projeto.Service.Services
{
    public class ServiceAtendimentoChamadoInstalacao : ServiceBase<AtendimentoChamadoInstalacao, AtendimentoChamadoInstalacaoDTO>, IServiceAtendimentoChamadoInstalacao
    {
        private readonly IRepositoryAtendimentoChamadoInstalacao _repositoryAtendimentoChamadoInstalacao;
        private readonly IMapper _mapper;

        public ServiceAtendimentoChamadoInstalacao(IMapper mapper, IRepositoryAtendimentoChamadoInstalacao repositoryAtendimentoChamadoInstalacao) : base(mapper, repositoryAtendimentoChamadoInstalacao)
        {
            _repositoryAtendimentoChamadoInstalacao = repositoryAtendimentoChamadoInstalacao;
            _mapper = mapper;
        }

        public int RegistraAtendimentoChamado(AtendimentoChamadoInstalacaoDTO atendimento)
        {
            return _repositoryAtendimentoChamadoInstalacao.RegistraAtendimentoChamado(_mapper.Map<AtendimentoChamadoInstalacao>(atendimento));
        }

        public int VerificaAtendimentoChamado(int numeroChamado)
        {
            return _repositoryAtendimentoChamadoInstalacao.VerificaAtendimentoChamado(numeroChamado);
        }
    }
}
