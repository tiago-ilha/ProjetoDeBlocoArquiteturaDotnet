using Alfa.Core.Repositorios;
using Alfa.Core.Servicos;
using Alfa.Core.Transacao;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Repositorios;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Servicos;
using System;

namespace PB.Solicitacoes.DomainServices.Modelos.Solicitacoes
{
	public class ServicoCadastrarSolicitacaoImp : ServicoBase<Solicitacao>, ServicoCadastrarSolicitacao
	{
		public ServicoCadastrarSolicitacaoImp(UnidadeDeTrabalho transacao, SolicitacaoRepositorio repositorio)
			: base(transacao, repositorio) { }

		public override void Executar(Solicitacao agregador)
		{
			base.Executar(agregador);
		}

		protected override void RegistrarOperacao(Solicitacao agregador)
		{
			if (EstaValido)
			{
				_repositorio.Salvar(agregador);
				_transacao.Comitar();
			}
			else
			{
				MesclarNotificacoes(agregador);
				_transacao.Desfazer();
			}
		}
	}
}
