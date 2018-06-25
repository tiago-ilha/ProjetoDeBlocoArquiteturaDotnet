using NHibernate;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.Repositorio;

namespace PB.Solicitacoes.Infra.Repositorios
{
    public class SolicitacaoDeClienteRepositorioImp : SolicitacaoDeClienteRepositorio
    {
        private readonly ISession _sessao;

        public SolicitacaoDeClienteRepositorioImp(ISession sessao)
        {
            _sessao = sessao;
        }

        public void Editar(SolicitacaoDoCliente solicitacao)
        {
            _sessao.SaveOrUpdate(solicitacao);
        }

        public void Remover(SolicitacaoDoCliente solicitacao)
        {
            _sessao.Delete(solicitacao);
        }

        public void Salvar(SolicitacaoDoCliente solicitacao)
        {
            _sessao.SaveOrUpdate(solicitacao);
        }
    }
}