using System;
using System.Collections.Generic;

namespace Projeto.Infra.Data.Repository.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
         void Add(TEntity item);
         void Remove(int id);
         void Update(TEntity item);
		 TEntity FindById(int id);
         IEnumerable<TEntity> FindAll();
    }
}
