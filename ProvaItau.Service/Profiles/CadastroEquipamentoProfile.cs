using System;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Service.DTO;

namespace Projeto.Service.Profiles
{
    public class CadastroEquipamentoProfile : Profile
    {
        public CadastroEquipamentoProfile()
        {
            CreateMap<CadastroEquipamento, CadastroEquipamentoDTO>();
        }
    }
}
