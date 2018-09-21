using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Repository.Contracts
{
	public interface IRepositoryChamadoInstalacao : IRepositoryBase<ChamadoInstalacao>
	{
		ChamadoInstalacao FindByNumber(int number);
	}
}
