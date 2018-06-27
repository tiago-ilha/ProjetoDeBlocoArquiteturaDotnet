using Alfa.Core.Validacoes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Repositorios;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Servicos;
using System;

namespace PB.Solicitacoes.DomainServices.Modelos.SolicitacoesDeClientes.Servicos
{
	public class ServicoDeferirSolicitacaoClienteImp : Notificar, ServicoDeferirSolicitacaoCliente
	{
		private SolicitacaoDeClienteRepositorio _repositorio;

		public ServicoDeferirSolicitacaoClienteImp(SolicitacaoDeClienteRepositorio repositorio)
		{
			_repositorio = repositorio;
		}

		public void Executar(Guid idSolicitacao)
		{
			var solicitacao = _repositorio.ObterPorId(idSolicitacao);

			solicitacao.Deferir();

			if (!solicitacao.EstaValido)
			{
				MesclarNotificacoes(solicitacao);
				return;
			}

			_repositorio.Salvar(solicitacao);
		}
	}
}
