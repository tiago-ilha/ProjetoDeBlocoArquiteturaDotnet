using System;

namespace PB.Solicitacoes.DomainModel.Modelos.Servicos
{
    public interface ServicoSolicitacaoDeCliente
    {
        void CadastrarSolicitacao(SolicitacaoDoCliente solicitacao);
        void DeferirSolicitacao(SolicitacaoDoCliente solicitacao);
    }
}
