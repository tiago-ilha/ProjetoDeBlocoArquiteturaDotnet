using Microsoft.EntityFrameworkCore;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.Repositorio;
using PB.Solicitacoes.Infra.Configuracoes;

namespace PB.Solicitacoes.Infra.Repositorios
{
    public class SolicitacaoDeClienteRepositorioImp : SolicitacaoDeClienteRepositorio
    {
        private readonly ContextoDeSolicitacoes _contexto;

        public SolicitacaoDeClienteRepositorioImp(ContextoDeSolicitacoes contexto)
        {
            _contexto = contexto;
        }

        public void Editar(SolicitacaoDoCliente solicitacao)
        {
            _contexto.Entry(solicitacao).State = EntityState.Modified;
        }

        public void Remover(SolicitacaoDoCliente solicitacao)
        {
            _contexto.Remove(solicitacao);
        }

        public void Salvar(SolicitacaoDoCliente solicitacao)
        {
            _contexto.Solicitacao.Add(solicitacao);
        }
    }
}