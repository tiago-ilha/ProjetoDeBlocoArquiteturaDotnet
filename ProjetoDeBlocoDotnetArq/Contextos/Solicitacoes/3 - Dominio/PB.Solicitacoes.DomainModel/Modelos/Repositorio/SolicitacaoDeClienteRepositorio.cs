using System;
namespace PB.Solicitacoes.DomainModel.Modelos.Repositorio
{
    public interface SolicitacaoDeClienteRepositorio
    {
        void Salvar(SolicitacaoDoCliente solicitacao);
        void Editar(SolicitacaoDoCliente solicitacao);
        void Remover(SolicitacaoDoCliente solicitacao);
    }
}
