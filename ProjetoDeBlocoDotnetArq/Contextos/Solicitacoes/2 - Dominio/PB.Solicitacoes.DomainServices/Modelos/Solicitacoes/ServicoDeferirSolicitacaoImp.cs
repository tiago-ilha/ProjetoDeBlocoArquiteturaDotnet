using Alfa.Core.Servicos;
using Alfa.Core.Transacao;
using Alfa.Core.Validacoes;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Repositorios;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Servicos;
using System;

namespace PB.Solicitacoes.DomainServices.Modelos.Solicitacoes
{
	public class ServicoDeferirSolicitacaoImp : ServicoBase<Solicitacao>, ServicoDeferirSolicitacao
	{
		public ServicoDeferirSolicitacaoImp(UnidadeDeTrabalho transacao, SolicitacaoRepositorio repositorio)
			: base(transacao, repositorio) { }

		public override void Executar(Solicitacao agregador)
		{
			agregador.Deferir();

			base.Executar(agregador);
		}
	}
}
