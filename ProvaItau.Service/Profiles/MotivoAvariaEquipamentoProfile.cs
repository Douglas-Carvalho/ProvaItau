using System;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Service.DTO;

namespace Projeto.Service.Profiles
{
    public class MotivoAvariaEquipamentoProfile : Profile
    {
        public MotivoAvariaEquipamentoProfile()
        {
            CreateMap<MotivoAvariaEquipamento, MotivoAvariaEquipamentoDTO>();
        }
    }
}
