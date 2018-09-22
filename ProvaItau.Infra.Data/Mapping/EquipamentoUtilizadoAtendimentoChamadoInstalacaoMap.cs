using System;
using Dapper.FluentMap.Dommel.Mapping;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Mapping
{
    public class EquipamentoUtilizadoAtendimentoChamadoInstalacaoMap : DommelEntityMap<EquipamentoUtilizadoAtendimentoChamadoInstalacao>
    {
        public EquipamentoUtilizadoAtendimentoChamadoInstalacaoMap()
        {
            ToTable("EquipamentoUtilizadoAtendimentoChamadoInstalacao");
            Map(x => x.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(x => x.Equipamento).Ignore();
            Map(x => x.Atendimento).Ignore();
            Map(x => x.Motivo).Ignore();
        }
    }
}
