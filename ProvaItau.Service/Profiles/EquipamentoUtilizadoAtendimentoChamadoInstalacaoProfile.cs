using System;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Service.DTO;

namespace Projeto.Service.Profiles
{
    public class EquipamentoUtilizadoAtendimentoChamadoInstalacaoProfile : Profile
    {
        public EquipamentoUtilizadoAtendimentoChamadoInstalacaoProfile()
        {
            CreateMap<EquipamentoUtilizadoAtendimentoChamadoInstalacao, EquipamentoUtilizadoAtendimentoChamadoInstalacaoDTO>();
        }
    }
}
