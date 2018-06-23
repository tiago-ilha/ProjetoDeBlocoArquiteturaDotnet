using System;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.Repositorio;
using PB.Solicitacoes.Infra.Configuracoes;

namespace PB.Solicitacoes.Infra.Repositorios
{
    public class SolicitacaoDeClienteRepositorioImp : SolicitacaoDeClienteRepositorio
    {
        // private readonly SolicitacoesContexto _contexto;

        // public SolicitacaoDeClienteRepositorioImp(SolicitacoesContexto contexto)
        // {
        //     _contexto = contexto;
        // }

        public void Editar(SolicitacaoDeCliente solicitacao)
        {
            // _contexto.Entry(solicitacao).State = EntityState.Modified;
        }

        public void Remover(SolicitacaoDeCliente solicitacao)
        {
            // _contexto.Remove(solicitacao);
        }

        public void Salvar(SolicitacaoDeCliente solicitacao)
        {
            // _contexto.Solicitacaos.Add(solicitacao);
        }
    }
}
