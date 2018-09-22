using System;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Service.DTO;

namespace Projeto.Service.Profiles
{
    public class AtendimentoChamadoInstalacaoProfile : Profile
    {
        public AtendimentoChamadoInstalacaoProfile()
        {
            CreateMap<AtendimentoChamadoInstalacao, AtendimentoChamadoInstalacaoDTO>();
        }
    }
}
