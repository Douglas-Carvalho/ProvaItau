using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Service.Services.Contracts
{
	public interface IServiceBase<TEntityDTO>
		where TEntityDTO : class 
	{
		void Add(TEntityDTO item);
		void Remove(int id);
		void Update(TEntityDTO item);
		TEntityDTO FindById(int id);
		IEnumerable<TEntityDTO> FindAll();
	}
}
