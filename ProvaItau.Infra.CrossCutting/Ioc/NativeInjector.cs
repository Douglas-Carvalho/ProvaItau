using Microsoft.Extensions.DependencyInjection;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repository;
using Projeto.Infra.Data.Repository.Contracts;
using Projeto.Service.Services;
using Projeto.Service.Services.Contracts;

namespace Projeto.Infra.CrossCutting.Ioc
{
	public class NativeInjector
	{
		public static void RegisterServices(IServiceCollection services)
		{
			services.AddScoped(typeof(IRepositoryChamadoInstalacao), typeof(RepositoryChamadoInstalacao));
            services.AddScoped(typeof(IRepositoryCadastroEquipamento), typeof(RepositoryCadastroEquipamento));
            services.AddScoped(typeof(IRepositoryMotivoAvariaEquipamento), typeof(RepositoryMotivoAvariaEquipamento));

            services.AddTransient(typeof(IServiceChamadoInstalacao), typeof(ServiceChamadoInstalacao));
            services.AddTransient(typeof(IServiceCadastroEquipamento), typeof(ServiceCadastroEquipamento));
            services.AddTransient(typeof(IServiceMotivoAvariaEquipamento), typeof(ServiceMotivoAvariaEquipamento));

            services.AddSingleton(typeof(ApplicationContext));
		}
	}
}
