﻿using System;
namespace PB.Solicitacoes.DomainModel.Modelos.Servicos
{
    public interface ServicoDeferirSolicitacao
    {
        void Executar(SolicitacaoDoCliente solicitacao);
    }
}
