using System;
namespace PB.Solicitacoes.DomainModel.Modelos.Servicos
{
    public interface ServicoCadastrarSolicitacao
    {
        void Executar(SolicitacaoDeCliente solicitacao);
    }
}
