using System;
using Projeto.Domain.Entities;
using Projeto.Service.DTO;

namespace Projeto.Service.Services.Contracts
{
    public interface IServiceAtendimentoChamadoInstalacao : IServiceBase<AtendimentoChamadoInstalacaoDTO>
    {
        int VerificaAtendimentoChamado(int numeroChamado);

        int RegistraAtendimentoChamado(AtendimentoChamadoInstalacaoDTO atendimento);
    }
}