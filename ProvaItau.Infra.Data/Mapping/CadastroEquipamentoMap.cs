using System;
using Dapper.FluentMap.Dommel.Mapping;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Mapping
{
    public class CadastroEquipamentoMap : DommelEntityMap<CadastroEquipamento>
    {
        public CadastroEquipamentoMap()
        {
            ToTable("CadastroEquipamento");
            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.Nome).ToColumn("NomeEquipamento");
            Map(x => x.Preco).ToColumn("PrecoEquipamento");
        }
    }
}
