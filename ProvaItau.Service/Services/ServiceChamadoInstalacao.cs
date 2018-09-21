using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Repository.Contracts;
using Projeto.Service.DTO;
using Projeto.Service.Services.Contracts;

namespace Projeto.Service.Services
{
	public class ServiceChamadoInstalacao : ServiceBase<ChamadoInstalacao, ChamadoInstalacaoDTO>, IServiceChamadoInstalacao
	{
		private readonly IRepositoryChamadoInstalacao _repositoryChamadoInstalacao;
		private readonly IMapper _mapper;

		public ServiceChamadoInstalacao(IMapper mapper, IRepositoryChamadoInstalacao repositoryChamadoInstalacao) : base(mapper, repositoryChamadoInstalacao)
		{
			_repositoryChamadoInstalacao = repositoryChamadoInstalacao;
			_mapper = mapper;
		}

        public ChamadoInstalacaoDTO FindByNumber(int number)
        {
            return _mapper.Map<ChamadoInstalacaoDTO>(_repositoryChamadoInstalacao.FindByNumber(number));
        }
	}
}
