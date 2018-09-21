using System;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Service.DTO;

namespace Projeto.Service.Profiles
{
    public class ResponsavelOrigemAvariaEquipamentoProfile : Profile
    {
        public ResponsavelOrigemAvariaEquipamentoProfile()
        {
            CreateMap<ResponsavelOrigemAvariaEquipamento, ResponsavelOrigemAvariaEquipamentoDTO>();
        }
    }
}
