using NHibernate;
using PB.Solicitacoes.DomainModel;

namespace PB.Solicitacoes.Infra.UnidadeDeTrabalho
{
    public class Transacao : ITransacao
    {
        private readonly ISession _sessao;
        private ITransaction _transacao;

        public Transacao(ISession sessao)
        {
            _sessao = sessao;
        }
        
        public void AbrirTransacao()
        {
           _transacao = _sessao.BeginTransaction();
        }

        public void Comitar()
        {
            if (_transacao != null && _transacao.IsActive)
                _transacao.Commit();
        }

        public void Desfazer()
        {
            if (_transacao != null && _transacao.IsActive)
                _transacao.Rollback();
        }

        public void Dispose()
        {
            _sessao.Dispose();
        }
    }
}