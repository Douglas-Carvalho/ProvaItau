using System;
using System.Collections.Generic;
using AutoMapper;
using Projeto.Infra.Data.Repository.Contracts;
using Projeto.Service.Services.Contracts;

namespace Projeto.Service.Services
{
	public class ServiceBase<TEntity, TEntityDTO> : IServiceBase<TEntityDTO> 
		where TEntity : class 
		where TEntityDTO : class
	{
		private readonly IMapper _mapper;
		private readonly IRepositoryBase<TEntity> _repositoryBase;

		public ServiceBase(IMapper mapper, IRepositoryBase<TEntity> repositoryBase)
		{
			_repositoryBase = repositoryBase;
			_mapper = mapper;
		}

		public void Add(TEntityDTO item)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TEntityDTO> FindAll()
		{
            IEnumerable<TEntityDTO> returnMap = null;

            try
            {
                var returnDomain = _repositoryBase.FindAll();

                returnMap = _mapper.Map<IEnumerable<TEntityDTO>>(returnDomain);
            }
            catch (AutoMapperMappingException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnMap;
        }

		public TEntityDTO FindById(int id)
		{
			TEntityDTO returnMap = null;

			try
			{
				var returnDomain = _repositoryBase.FindById(id);

				returnMap = _mapper.Map<TEntityDTO>(returnDomain);
			}
			catch (AutoMapperMappingException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return returnMap;
		}

		public void Remove(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(TEntityDTO item)
		{
			throw new NotImplementedException();
		}
	}
}
