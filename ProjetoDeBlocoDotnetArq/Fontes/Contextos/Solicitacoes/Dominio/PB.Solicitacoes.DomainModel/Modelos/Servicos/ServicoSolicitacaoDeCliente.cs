using System;
namespace PB.Solicitacoes.DomainModel.Modelos.Servicos
{
    public interface ServicoSolicitacaoDeCliente
    {
        void CadastrarSolicitacao(SolicitacaoDeCliente solicitacao);
        void DeferirSolicitacao(SolicitacaoDeCliente solicitacao);
    }
}
