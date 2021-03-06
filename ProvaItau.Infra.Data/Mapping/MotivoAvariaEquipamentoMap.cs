﻿using System;
using Dapper.FluentMap.Dommel.Mapping;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Mapping
{
    public class MotivoAvariaEquipamentoMap : DommelEntityMap<MotivoAvariaEquipamento>
    {
        public MotivoAvariaEquipamentoMap()
        {
            ToTable("MotivoAvariaEquipamento");
            Map(x => x.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(x => x.MotivoAvaria).ToColumn("TextoPadraoMotivoAvariaEquipamento");
            Map(x => x.Responsavel).Ignore();
        }
    }
}
