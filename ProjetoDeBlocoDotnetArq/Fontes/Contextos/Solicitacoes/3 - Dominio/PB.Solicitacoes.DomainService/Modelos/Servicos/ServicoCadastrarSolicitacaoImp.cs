using System;
using PB.Solicitacoes.DomainModel;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.Repositorio;
using PB.Solicitacoes.DomainModel.Modelos.Servicos;

namespace PB.Solicitacoes.DomainService.Modelos.Servicos
{
    public class ServicoCadastrarSolicitacaoImp : ServicoCadastrarSolicitacao
    {
        private readonly SolicitacaoDeClienteRepositorio _repositorio;
        private readonly ITransacao _transacao;

        public ServicoCadastrarSolicitacaoImp(ITransacao transacao, SolicitacaoDeClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
            _transacao = transacao;
        }

        public void Executar(SolicitacaoDoCliente solicitacao)
        {
            _transacao.AbrirTransacao();

            try
            {
                _repositorio.Salvar(solicitacao);
            }
            catch (Exception)
            {
                _transacao.Desfazer();
            }
            finally
            {
                _transacao.Dispose();
            }
        }
    }
}