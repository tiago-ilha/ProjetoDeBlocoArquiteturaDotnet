using System;
namespace PB.Solicitacoes.DomainModel.Modelos.Repositorio
{
    public interface SolicitacaoDeClienteRepositorio
    {
        void Salvar(SolicitacaoDeCliente solicitacao);
        void Editar(SolicitacaoDeCliente solicitacao);
        void Remover(SolicitacaoDeCliente solicitacao);
    }
}
