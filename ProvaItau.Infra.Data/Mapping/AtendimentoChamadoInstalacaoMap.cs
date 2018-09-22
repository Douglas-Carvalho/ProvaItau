using System;
using Dapper.FluentMap.Dommel.Mapping;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Mapping
{
    public class AtendimentoChamadoInstalacaoMap : DommelEntityMap<AtendimentoChamadoInstalacao>
    {
        public AtendimentoChamadoInstalacaoMap()
        {
            ToTable("AtendimentoChamadoInstalacao");
            Map(x => x.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(x => x.Data).ToColumn("dataAtendimento");
            Map(x => x.Chamado).Ignore();
        }
    }
}
