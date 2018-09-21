using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Service.DTO;

namespace Projeto.Service.Profiles
{
	public class ChamadoInstalacaoProfile : Profile
	{
		public ChamadoInstalacaoProfile() {
			CreateMap<ChamadoInstalacao, ChamadoInstalacaoDTO>();
		}
	}
}
