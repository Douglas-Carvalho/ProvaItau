using System;
using Dapper.FluentMap.Dommel.Mapping;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Mapping
{
    public class ChamadoInstalacaoMap : DommelEntityMap<ChamadoInstalacao>
    {
        public ChamadoInstalacaoMap()
        {
            ToTable("ChamadoInstalacao");
            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.Numero).ToColumn("NumeroChamado");
        }
    }
}
