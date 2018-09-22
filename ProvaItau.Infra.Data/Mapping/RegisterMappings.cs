using System;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Mapping
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ChamadoInstalacaoMap());
                config.AddMap(new CadastroEquipamentoMap());
                config.AddMap(new MotivoAvariaEquipamentoMap());
                config.AddMap(new ResponsavelOrigemAvariaEquipamentoMap());
                config.AddMap(new AtendimentoChamadoInstalacaoMap());
                config.AddMap(new EquipamentoUtilizadoAtendimentoChamadoInstalacaoMap());
                config.ForDommel();
            });
        }
    }
}
