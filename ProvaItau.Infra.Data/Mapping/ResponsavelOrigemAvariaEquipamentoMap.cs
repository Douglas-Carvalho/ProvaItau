using System;
using Dapper.FluentMap.Dommel.Mapping;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Mapping
{
    public class ResponsavelOrigemAvariaEquipamentoMap : DommelEntityMap<ResponsavelOrigemAvariaEquipamento>
    {
        public ResponsavelOrigemAvariaEquipamentoMap()
        {
            ToTable("ResponsavelOrigemAvariaEquipamento");
            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.Responsavel).ToColumn("NomeGrupoResponsavelOrigemAvariaEquipamento");
        }
    }
}
